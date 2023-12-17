using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxBGMov : MonoBehaviour
{
    [SerializeField] private Vector2 movSpeed;
    private Vector2 _offset;
    private Material _material;
    private Rigidbody2D _rb2DPlayer;

    private void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
        _rb2DPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _offset = (_rb2DPlayer.velocity.x * 0.1f) * movSpeed * Time.deltaTime;
        _material.mainTextureOffset += _offset;
    }
}
