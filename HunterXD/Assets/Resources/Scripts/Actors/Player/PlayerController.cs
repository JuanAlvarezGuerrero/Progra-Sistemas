using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor, IPlayer
{
    private PlayerStatesEnum _playerState = PlayerStatesEnum.Alive;
    
    private PlayerStats _playerStats; 
    #region Parameters
    private float _horizontal;
    [SerializeField] private bool _isFacingRight = true;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Vector2 _dimensionBox;
    private bool inFloor;
    private bool jumping;
    
    [SerializeField] private Animator _anim;
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

    private void Awake()
    {
        _playerStats = _stats as PlayerStats;
    }

    private void Update()
    {
        if (_playerState == PlayerStatesEnum.Alive)
        {
            IsAlive(_currentLife);
            Attack();
            if (Input.GetKeyDown(_attack))
            {
                TakeDamage(5);
            }
        
            _anim.SetFloat("speed", Math.Abs(_rb.velocity.x));
        
        
            if (Input.GetKeyDown(_jump))
            {
                jumping = true;
            }
            inFloor=Physics2D.OverlapBox( _groundCheck.position, _dimensionBox, 0, _playerStats.GroundLayer);
            _anim.SetBool("isJumping", !inFloor);
        
            Flip();    
        }
        if(_playerState == PlayerStatesEnum.Dead)
        {
            _anim.SetTrigger("isDead");
        }
        
    }

    private void FixedUpdate()
    {
        if (_playerState == PlayerStatesEnum.Alive)
        {
            Vector2 dir= new Vector2( _horizontal = Input.GetAxisRaw("Horizontal"), _rb.velocity.y);
            
            Move(dir);
            if (jumping && inFloor)
            {
                Jump();
            }
            jumping = false;
        }
    }

    #region Public_Methods
    public void Move(Vector2 dir) // Hacer con "DO"
    {
        _rb.velocity = new Vector2(dir.x * _playerStats.Speed, _rb.velocity.y);
    }

    public void Attack() // Hacer con "DO"
    {
        if (Input.GetKeyDown(_attack))
        {
            _anim.SetTrigger("isAttacking");
        }
    }

    public void Jump() // Hacer con "DO"
    {
        _rb.AddForce(Vector2.up * _playerStats.JumpingPower, ForceMode2D.Impulse);
        inFloor = false;
    }

    public void SwitchPower() // Hacer con "DO"
    {
        throw new System.NotImplementedException();
    }

    private void IsAlive(int currentLife)
    {
        if (currentLife < 0)
        {
            _playerState = PlayerStatesEnum.Dead;
        }
    }
    #endregion

    #region Private_Methods
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
    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireCube(_groundCheck.position, _dimensionBox);
    }

    #endregion
}
