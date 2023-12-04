using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum TypeABB
{
    PreOrder,
    InOrder,
    PostOrder
}
public class SwitchABB : MonoBehaviour
{
    public TypeABB ExecuteABB;
    public GameObject text;
    public ABB _abb;
    //public GameObject[] objectsABB;
    
    public bool isActive;
    [SerializeField] private List<GameObject> _imgSwitch;
    [SerializeField] private List<GameObject> _switchOFF;
    [SerializeField] private List<GameObject> _switchON;

    private void Start()
    {
        //_abb = GetComponent<ABB>();
        //objectsABB = new GameObject[4];
        _imgSwitch[0].gameObject.SetActive(true);
        _imgSwitch[1].gameObject.SetActive(false);
        //_abb.PlatformValues = new List<float>();
    }

    private void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.E))
        {
            _imgSwitch[1].gameObject.SetActive(true);
            _imgSwitch[0].gameObject.SetActive(false);

            if (ExecuteABB == TypeABB.PreOrder)
            {
                _abb.preOrder(_abb.raiz);
                for (int i = 0; i < _switchOFF.Count; i++)
                {
                    _switchON[i].gameObject.SetActive(false);
                    _switchOFF[i].gameObject.SetActive(true);
                }
            }
            else if (ExecuteABB == TypeABB.InOrder)
            {
                _abb.inOrder(_abb.raiz);
                for (int i = 0; i < _switchOFF.Count; i++)
                {
                    _switchON[i].gameObject.SetActive(false);
                    _switchOFF[i].gameObject.SetActive(true);
                }
            }
            else if (ExecuteABB == TypeABB.PostOrder)
            {
                _abb.postOrder(_abb.raiz);
                for (int i = 0; i < _switchOFF.Count; i++)
                {
                    _switchON[i].gameObject.SetActive(false);
                    _switchOFF[i].gameObject.SetActive(true);
                }
            }
            for (int i = 0; i < _abb.objectsABB.Length; i++)
            {
                _abb.objectsABB[i].transform.localScale = new Vector3(_abb.PlatformValues[i], _abb.objectsABB[i].transform.localScale.y, _abb.objectsABB[i].transform.localScale.z);
            }
            _abb.PlatformValues.Clear();
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
