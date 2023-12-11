using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private GameObject _imageConfirm;
    [SerializeField] private float _timer;
    [SerializeField] private GameObject[] _storyScreens;
    [SerializeField] private int index;
    [SerializeField] private int levelToLoad;

    public int Index() => index;
    public GameObject[] StoryScreens() => _storyScreens;
    
    void Start()
    {
        _timer = 2f;
        foreach (GameObject screen in _storyScreens)
        {
            screen.SetActive(false);
        }
        index = 0;
        _storyScreens[index].SetActive(true);        
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0f)
        {
            _imageConfirm.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space) && _storyScreens.Length>index)
            {
                NextPage();
                _imageConfirm.SetActive(false);
                _timer = 2f;
            }

            if (_storyScreens.Length == index)
            {
                OnFadeComplete();
            }
        }
    }

    public void NextPage()
    {
        if (index < _storyScreens.Length)
        {
            Debug.Log(index);
            _storyScreens[index].SetActive(false);
            index++;
            if (index < _storyScreens.Length)
            {
                _storyScreens[index].SetActive(true);
            }
        }
    } 
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
