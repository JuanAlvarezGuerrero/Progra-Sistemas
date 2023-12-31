using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class BasicArrow : MonoBehaviour, IArrow
{
    #region SOParameters

    [SerializeField] private ArrowStats _arrowStats;
    
    #endregion
    public float Speed => _arrowStats.Speed;
    public float LifeTime => _arrowStats.LifeTime;
    public LayerMask HitteableLayer => _arrowStats.HitteableLayer;
    public IWeapon Owner => _owner;

    [SerializeField] private float _lifeTime;
    [SerializeField] private IWeapon _owner;

    private Collider _collider;
    private Rigidbody _rigidbody;

    public GameObject MyGameObject => gameObject;

    private void Start()
    {
        _lifeTime = LifeTime;
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Travel();
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0) Destroy(this.gameObject);
    }

    public void Travel()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    public void Init()
    {
        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    public void SetOwner(IWeapon weapon) => _owner = weapon;

    public IProduct Clone()
    {
        return Instantiate(this);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & HitteableLayer) != 0)
        {
            if (collision.GetComponent<Actor>() != null)
            {
                GameManager.instance.AddEvents(new CmdTakeDamage(collision.GetComponent<Actor>(), _owner.Damage));
                Destroy(gameObject);
                AudioManager.Instance.PlaySFX(5, 0.5f);
            }
            Destroy(gameObject);
        }
    }
}
