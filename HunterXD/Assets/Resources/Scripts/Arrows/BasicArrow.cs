using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class BasicArrow : MonoBehaviour, IArrow
{
    public float Speed => _speed;
    public float LifeTime => _lifeTime;
    public LayerMask HitteableLayer => _hitteableLayer;
    public IWeapon Owner => _owner;

    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private LayerMask _hitteableLayer;
    [SerializeField] private IWeapon _owner;

    private Collider _collider;
    private Rigidbody _rigidbody;

    public GameObject MyGameObject => gameObject;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        //Init();
    }

    private void Update()
    {
        Travel();

        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0) Destroy(this.gameObject);
    }

    public void Travel()
    {
        transform.position += transform.right * Time.deltaTime * _speed;
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

    public void Damage(IActor actor, int dmg)
    {
        throw new System.NotImplementedException();
    }

    /*public void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _hitteableLayer) != 0)
        {
            if (other.GetComponent<Actor>() != null)
            {
                GameManager.instance.AddEvents(new CmdTakeDamage(other.GetComponent<Actor>(), _owner.Damage));
                Destroy(gameObject);
            }
        }
    }*/
}
