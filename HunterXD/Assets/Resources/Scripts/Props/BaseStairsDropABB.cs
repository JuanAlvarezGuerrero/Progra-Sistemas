using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseStairsDropABB : MonoBehaviour
{
    public GameObject text;
    [SerializeField] private SwitchABB _switch;
    public int index;
    public List<Transform> _stairPosition;
    public Pila Pila;
    private bool isPlayerOn;

    private void Start()
    {
        isPlayerOn = false;
        index = 0;
        Pila.InicializarPila(4);
    }

    private void Update()
    {
        if (isPlayerOn && Input.GetKeyDown(KeyCode.G))
        {
            if (!Pila.PilaVacia())
            {
                if (index < 5)
                {
                    GameObject item = Pila.Tope();
                    item.transform.position = _stairPosition[index].position;
                    item.gameObject.SetActive(true);
                    item.GetComponent<BoxCollider2D>().isTrigger = false;
                    _switch.objectsABB[index] = item;
                    float value = item.GetComponent<PlatformInfo>().Info;
                    Debug.Log(value);
                    _switch._abb.AgregarElem(ref _switch._abb.raiz, value);
                    Pila.Desapilar();
                }
                index++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            isPlayerOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(false);
            isPlayerOn = false;
        }    
    }
}
