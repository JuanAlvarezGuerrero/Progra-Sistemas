using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private ItemFactory _itemFactory;
    private Animator _anim;
    public bool _chestClosed;
    public bool _canOpen;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _canOpen = false;
        _chestClosed = true;
        
        _itemFactory = new ItemFactory();
    }

    private void SpawnItem()
    {
        IProduct item = _itemFactory.CreateProduct();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canOpen)
        {
            _anim.Play("GoldenChestOpen");
            _chestClosed = false;
        }
    }
    
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _chestClosed)
        {
            _canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _chestClosed)
        {
            _canOpen = false;
        }
    }
    
}
