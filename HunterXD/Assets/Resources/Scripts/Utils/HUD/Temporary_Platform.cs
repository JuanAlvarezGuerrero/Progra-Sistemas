using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary_Platform : MonoBehaviour
{
    #region PRIVATE_PARAMETERS
    [SerializeField] private float _timeWaiting;
    [SerializeField] private float _speedRotation;

    private Rigidbody2D _rb2D;
    private bool _drop = false;
    #endregion

    #region UNITY_METHODS
    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Drop(other));
        }
    }

    private IEnumerator Drop(Collision2D other)
    {
        yield return new WaitForSeconds(_timeWaiting);
        _drop = true;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), other.transform.GetComponent<Collider2D>());
        _rb2D.constraints = RigidbodyConstraints2D.None;
        _rb2D.AddForce(new Vector2(0.1f, 0));
    }
    #endregion

}
