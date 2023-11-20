using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private bool isActive;
    [SerializeField] private List<GameObject> _imgSwitch;

    private void Start()
    {
        _imgSwitch[0].gameObject.SetActive(true);
        _imgSwitch[1].gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.E))
        {
            _imgSwitch[1].gameObject.SetActive(true);
            _imgSwitch[0].gameObject.SetActive(false);
            isActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isActive = true;
    }
}
