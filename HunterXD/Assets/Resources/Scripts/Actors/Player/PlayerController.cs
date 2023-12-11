using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Actor, IPlayer
{
    [SerializeField] private LifeBar _lifeBar;
    private float _deadTimer = 2f;
    [SerializeField] private LevelChanger _levelChanger; 
    private bool canAttack;
    private bool canSpecialAttack;
    private float _cdShootArrow;
    [SerializeField] private float _cdShootSpecialArrow;

    [SerializeField] private BaseStairsDropABB _baseStairsDropABB;
    [SerializeField] private BaseStairsDrop _baseStairsDrop;
    
    private PlayerStatesEnum _playerState = PlayerStatesEnum.Alive;
    private PlayerStats _playerStats;
    [SerializeField] private Pila pila;
    [SerializeField] private Weapon _weapon;
    

    #region Parameters
    [SerializeField] private bool _isFacingRight = true;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Vector2 _dimensionBox;
    [SerializeField] private Animator _anim;
    [SerializeField] private Rigidbody2D _rb;
    private float _horizontal;
    private bool inFloor;
    private bool jumping;
    #endregion
    
    #region Controls
    [Header("Controls")]
    [SerializeField] private KeyCode _jump = KeyCode.Space;
    [SerializeField] private KeyCode _attack = KeyCode.Mouse0;
    #endregion

    #region CustomJump

    [Range(0, 1)] [SerializeField] private float multiplierCancelJump;
    [SerializeField] private float multiplierGravity;
    private float _gravityScale;
    private bool buttonJumpUp = true;

    

    #endregion
    private void Awake()
    {
        _playerStats = _stats as PlayerStats;
        pila.InicializarPila(4);
        _gravityScale = _rb.gravityScale;
        _lifeBar.InitLifeBar();
    }

    private void Update()
    {
        if (_playerState == PlayerStatesEnum.Alive)
        {
            IsAlive(_currentLife);
            Attack();
            SpecialAttack();
            Flip();
            _cdShootArrow -= Time.deltaTime;

            if (_cdShootArrow < 0)
            {
                canAttack = true;
            }
            if (_cdShootSpecialArrow < 0)
            {
                canSpecialAttack = true;
            }

            if (Input.GetKey(_jump))
            {
                jumping = true;
            }

            if (Input.GetKeyUp(_jump))
            {
                ButtonJumpUp();
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                GameObject item = pila.Tope();
                item.gameObject.SetActive(true);
                item.transform.position = new Vector2(transform.position.x+3,transform.position.y+1);
                pila.Desapilar();
            }
            
            inFloor=Physics2D.OverlapBox( _groundCheck.position, _dimensionBox, 0, _playerStats.GroundLayer);
            _anim.SetBool("isJumping", !inFloor);
            _anim.SetFloat("speed", Math.Abs(_rb.velocity.x));

            if (_currentLife <= 0)
            {
                AudioManager.Instance.PlaySFX(11);
                _playerState = PlayerStatesEnum.Dead;
            }
        }

        if(_playerState == PlayerStatesEnum.Dead)
        {
            _anim.SetTrigger("isDead");
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            
            _deadTimer -= Time.deltaTime;
            if (_deadTimer<0f)
            {
                _levelChanger.FadeToLevel(5);
            }
        }
    }

    private void ButtonJumpUp()
    {
        if (_rb.velocity.y > 0)
        {
            _rb.AddForce(Vector2.down * _rb.velocity.y * (1 - multiplierCancelJump), ForceMode2D.Impulse);
        }

        buttonJumpUp = true;
        jumping = false;
    }
    private void FixedUpdate()
    {
        if (_playerState == PlayerStatesEnum.Alive)
        {
            Vector2 dir= new Vector2( _horizontal = Input.GetAxisRaw("Horizontal"), _rb.velocity.y);
            Move(dir);
            if (jumping && buttonJumpUp && inFloor)
            {
                Jump();
            }

            if (_rb.velocity.y < 0 && !inFloor)
            {
                _rb.gravityScale = _gravityScale * multiplierGravity;
            }
            else
            {
                _rb.gravityScale = _gravityScale;
            }
            
            jumping = false;
        }
    }

    #region Public_Methods
    public void Move(Vector2 dir)
    {
        _rb.velocity = new Vector2(dir.x * _playerStats.Speed, _rb.velocity.y);
    }

    public void Attack()
    {
        if (Input.GetKeyDown(_attack) && canAttack)
        {
            AudioManager.Instance.PlaySFX(2,1f);
            _anim.SetTrigger("isAttacking");
            _weapon.Shoot();
            _cdShootArrow = _playerStats.TimerShootArrow;
            canAttack = false;
        }
    }
    public void SpecialAttack()
    {
        if (Input.GetMouseButton(1))
        {
            _cdShootSpecialArrow -= Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (_cdShootSpecialArrow <= -2)
            {
                AudioManager.Instance.PlaySFX(2, 1f);
                _anim.SetTrigger("isAttacking");
                _weapon.SpecialShoot();
                canAttack = false;
                _cdShootArrow = 1.5f;
                _cdShootSpecialArrow =2;
                canSpecialAttack = false;
                _cdShootSpecialArrow = 0; 
            }
            else
            {
                _cdShootSpecialArrow = 0;
            }
        }
    }

    public void Jump()
    {
        _rb.AddForce(Vector2.up * _playerStats.JumpingPower, ForceMode2D.Impulse);
        inFloor = false;
        jumping = false;
        buttonJumpUp = false;
    }

    public void SwitchPower()
    {
        throw new System.NotImplementedException();
    }

    private void IsAlive(int currentLife)
    {
        if (currentLife <= 0)
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
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireCube(_groundCheck.position, _dimensionBox);
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjetoPuzzle"))
        {
            AudioManager.Instance.PlaySFX(1, 1f);
            Debug.Log("Objeto Puzzle");
            _baseStairsDropABB.Pila.Apilar(collision.gameObject);
            
            collision.gameObject.SetActive(false);
        }
        else if(collision.CompareTag("ObjetoCola"))
        {
            AudioManager.Instance.PlaySFX(1, 1f);
            Debug.Log("Objeto Cola");
            _baseStairsDrop._cola.Acolar(collision.gameObject);
            
            collision.gameObject.SetActive(false);
        }
        else if(collision.CompareTag("Potion"))
        {
            AudioManager.Instance.PlaySFX(0, 1f);
            GetLife(1);
            _lifeBar.ChangeCurrentLife(_currentLife);
        }
        if (collision.CompareTag("Enemy")||collision.CompareTag("Trap"))
        {
            TakeDamage(1);
            _lifeBar.ChangeCurrentLife(_currentLife);
            AudioManager.Instance.PlaySFX(4);
        }

        if (collision.CompareTag("Portal"))
        {
            AudioManager.Instance.PlaySFX(10);
        }
        if (collision.CompareTag("DeadLine")&& _playerState == PlayerStatesEnum.Alive)
        {
            AudioManager.Instance.PlaySFX(11);
        }
    }
}
