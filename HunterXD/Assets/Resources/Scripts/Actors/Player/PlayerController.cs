using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Actor, IPlayer
{
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

    private void Awake()
    {
        _playerStats = _stats as PlayerStats;
        pila.InicializarPila(4);
    }

    private void Update()
    {
        if (_playerState == PlayerStatesEnum.Alive)
        {
            IsAlive(_currentLife);
            Attack();
            Flip();

            if (Input.GetKeyDown(_jump))
            {
                jumping = true;
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
                _playerState = PlayerStatesEnum.Dead;
            }
        }

        if(_playerState == PlayerStatesEnum.Dead)
        {
            _anim.SetTrigger("isDead");
            SceneManager.LoadScene(5);
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
    public void Move(Vector2 dir)
    {
        _rb.velocity = new Vector2(dir.x * _playerStats.Speed, _rb.velocity.y);
    }

    public void Attack()
    {
        if (Input.GetKeyDown(_attack))
        {
            AudioManager.Instance.PlaySFX(2,1f);
            _anim.SetTrigger("isAttacking");
            _weapon.Shoot();
        }
    }

    public void Jump()
    {
        _rb.AddForce(Vector2.up * _playerStats.JumpingPower, ForceMode2D.Impulse);
        inFloor = false;
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
        }
        if (collision.CompareTag("Enemy")||collision.CompareTag("Trap"))
        {
            TakeDamage(1);
            AudioManager.Instance.PlaySFX(4);
        }

        if (collision.CompareTag("Portal"))
        {
            AudioManager.Instance.PlaySFX(10);
        }
    }
}
