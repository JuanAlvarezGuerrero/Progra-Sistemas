using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SwitchABB : MonoBehaviour
{
    public GameObject text;
    public ABB _abb;
    public GameObject[] objectsABB;
    
    private bool isActive;
    [SerializeField] private List<GameObject> _imgSwitch;

    private void Start()
    {
        _abb = GetComponent<ABB>();
        objectsABB = new GameObject[4];
        _imgSwitch[0].gameObject.SetActive(true);
        _imgSwitch[1].gameObject.SetActive(false);
        _abb.PlatformValues = new List<float>();
    }

    private void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.E))
        {
            _imgSwitch[1].gameObject.SetActive(true);
            _imgSwitch[0].gameObject.SetActive(false);
            //_abb.preOrder(_abb.raiz);
            //_abb.inOrder(_abb.raiz);
            _abb.postOrder(_abb.raiz);
            for (int i = 0; i < objectsABB.Length; i++)
            {
                objectsABB[i].transform.localScale = new Vector3(objectsABB[i].transform.localScale.x,_abb.PlatformValues[i], objectsABB[i].transform.localScale.z);
            }
            isActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        text.gameObject.SetActive(true);
        isActive = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        text.gameObject.SetActive(false);
        isActive = false;
    }
}
