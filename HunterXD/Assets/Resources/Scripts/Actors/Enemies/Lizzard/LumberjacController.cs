using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjacController : Actor, IActor
{
    #region Parameters_Private
    [SerializeField] private LumberjacStates _lumberjacStates = LumberjacStates.patrol;


    private float _speed;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float distanceCheck;
    [SerializeField] private bool _movingRight;
    private Rigidbody2D _rb2D;

    [SerializeField] private Animator _anim;
    
    #endregion
    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _speed = _stats.MovementSpeed;
    }

    private void FixedUpdate()
    {
        
        if (_lumberjacStates == LumberjacStates.patrol)
        {
            RaycastHit2D floorData = Physics2D.Raycast(_groundCheck.position, Vector2.down, distanceCheck);
            _rb2D.velocity = new Vector2(_speed, _rb2D.velocity.y);
            if (floorData == false)
            {
                Flip();
            }
            if (_currentLife <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void Flip()
    {
        _movingRight = !_movingRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        _speed *= -1;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_groundCheck.transform.position,
            _groundCheck.transform.position + Vector3.down * distanceCheck);
    }
    
    public void Move(Vector2 dir)
    {
        throw new System.NotImplementedException();
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }
}
