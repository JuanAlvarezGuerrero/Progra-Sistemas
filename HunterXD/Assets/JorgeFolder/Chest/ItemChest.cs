using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemChest : MonoBehaviour, IItem
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
    
    public IProduct Clone()
    {
        return Instantiate(this);
    }

    public GameObject MyGameObject => gameObject;
}
