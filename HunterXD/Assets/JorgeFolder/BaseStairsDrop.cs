using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseStairsDrop : MonoBehaviour
{
    [SerializeField] private Switch _switch;
    public int index;
    public List<Transform> _stairPosition;
    public Cola _cola;
    private bool isPlayerOn;

    private void Start()
    {
        isPlayerOn = false;
        index = 0;
        _cola.InicializarCola(4);
    }

    private void Update()
    {
        if (isPlayerOn && Input.GetKeyDown(KeyCode.G))
        {
            if (!_cola.ColaVacia())
            {
                if (index < 4)
                {
                    GameObject item = _cola.Primero();
                    item.transform.position = _stairPosition[index].position;
                    item.gameObject.SetActive(true);
                    //Collider col = GetComponent<Collider>();
                    item.GetComponent<BoxCollider2D>().isTrigger = false;
                    _switch.objetosQuickSort[index] = item;
                    _cola.Desacolar();
                }
                index++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOn = false;
        }    
    }
}
