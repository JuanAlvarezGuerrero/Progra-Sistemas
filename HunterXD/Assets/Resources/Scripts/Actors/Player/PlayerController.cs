using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : Actor, IPlayer
{
    private PlayerStatesEnum _playerState = PlayerStatesEnum.Alive;
    private PlayerStats _playerStats;
    [SerializeField] private Pila pila;
    [SerializeField] private Quicksort quicksort;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private GameObject[] objetosPrueba;

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
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _jump = KeyCode.Space;
    [SerializeField] private KeyCode _attack = KeyCode.Mouse0;
    [SerializeField] private KeyCode _changePower = KeyCode.Mouse1;
    #endregion

    private void Awake()
    {
        _playerStats = _stats as PlayerStats;
        pila.InicializarPila(3);
        //_weapon.GetComponent<Weapon>();
    }
    //private void Start()
    //{
    //    pila.InicializarPila(3);
    //}
    private void Update()
    {
        if (_playerState == PlayerStatesEnum.Alive)
        {
            IsAlive(_currentLife);
            Attack();
            Flip();

            if (Input.GetKeyDown(_attack))
            {
                //TakeDamage(5);
            }

            if (Input.GetKeyDown(_jump))
            {
                jumping = true;
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                GameObject item = pila.Tope();
                item.gameObject.SetActive(true);
                item.transform.position = transform.position;
                pila.Desapilar();
                
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                quicksort.RunQuicksort(objetosPrueba, 0, objetosPrueba.Length - 1);
            }
            inFloor=Physics2D.OverlapBox( _groundCheck.position, _dimensionBox, 0, _playerStats.GroundLayer);
            _anim.SetBool("isJumping", !inFloor);
            _anim.SetFloat("speed", Math.Abs(_rb.velocity.x));
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
            _weapon.Shoot();
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
            Debug.Log("Objeto Puzzle");
            pila.Apilar(collision.gameObject);
            
            collision.gameObject.SetActive(false);
        }
        else if(collision.CompareTag("Potion"))
        {
            if(_currentLife<5)
                _currentLife++;
        }
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(50);
        }
    }
}
