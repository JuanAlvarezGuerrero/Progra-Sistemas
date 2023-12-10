using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chest : MonoBehaviour
{
    public GameObject text;
    public List<ItemChest> Items;
    public GameObject SpawnPosition;
    
    private ItemFactory _itemFactory;
    private Animator _anim;
    public bool _chestClosed;
    public bool _canOpen;
    

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _canOpen = false;
        _chestClosed = true;
        
        ItemChest item = Items[RandomItem()];
        _itemFactory = new ItemFactory(item);
    }
    private int RandomItem()
    {
        int random = Random.Range(0, Items.Count);
        return random;
    }
    private void SpawnItem()
    {
        IProduct item = _itemFactory.CreateProduct();
        GameObject itemObject = item.MyGameObject;
        itemObject.transform.position = SpawnPosition.transform.position;
        itemObject.transform.rotation = SpawnPosition.transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canOpen)
        {
            AudioManager.Instance.PlaySFX(7);
            _anim.Play("GoldenChestOpen");
            _chestClosed = false;
            _canOpen = false;
            SpawnItem();
            text.gameObject.SetActive(false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _chestClosed)
        {
            text.gameObject.SetActive(true);
            _canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _chestClosed)
        {
            text.gameObject.SetActive(false);
            _canOpen = false;
        }
    }
}
