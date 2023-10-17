using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : Actor, IPlayer
{
    #region Parameters
    private float _horizontal;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private bool _isFacingRight = true;

    [SerializeField] private float _jumpingPower;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Vector2 _dimensionBox;
    [SerializeField] private LayerMask _groundLayer;
    private bool inFloor;
    private bool jumping;
    
    public Animator _anim;
    [SerializeField] private Rigidbody2D _rb;
    #endregion
    
    #region Controls
    [Header("Controls")]
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _jump = KeyCode.Space;
    [SerializeField] private KeyCode _attack = KeyCode.Mouse0;
    [SerializeField] private KeyCode _changePower = KeyCode.Mouse1;
    #endregion

    
    private void Update()
    {
        _anim.SetFloat("speed", Math.Abs(_rb.velocity.x));
        Move();
        
        if (Input.GetKeyDown(_jump))
        {
            jumping = true;
        }
        inFloor=Physics2D.OverlapBox(_groundCheck.position, _dimensionBox, 0, _groundLayer);
        _anim.SetBool("isJumping", !inFloor);
        
        Flip();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
        
        if (jumping && inFloor)
        {
            Jump();
        }
        jumping = false;
    }

    public void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void Flip()
    {
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void Attack()
    {
        
    }

    public void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpingPower, ForceMode2D.Impulse);
        inFloor = false;
    }

    public void SwitchPower()
    {
        throw new System.NotImplementedException();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireCube(_groundCheck.position, _dimensionBox);
    }
}
