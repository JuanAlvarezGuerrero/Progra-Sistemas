using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //[SerializeField] private Cola _cola;
    
    [SerializeField] private Quicksort quicksort;
    [SerializeField] public GameObject[] objetosQuickSort;

    private bool isActive;
    [SerializeField] private List<GameObject> _imgSwitch;

    private void Start()
    {
        quicksort = GetComponent<Quicksort>();
        objetosQuickSort = new GameObject[4];
        _imgSwitch[0].gameObject.SetActive(true);
        _imgSwitch[1].gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.E))
        {
            _imgSwitch[1].gameObject.SetActive(true);
            _imgSwitch[0].gameObject.SetActive(false);
            quicksort.RunQuicksort(objetosQuickSort, 0, objetosQuickSort.Length - 1);
            //quicksort.RunQuicksort(_cola.objetosCola, 0, _cola.objetosCola.Length - 1);
            isActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isActive = true;
    }
}
