using System;using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState{
    inMenu,
    inGame
}

public class Menu : MonoBehaviour
{
    public GameState GameState; 
    
    #region PUBLIC_PARAMETERS
    public GameObject ObPause;
    public bool Pause = true;
    #endregion

    #region PRIVATE_PARAMETERS
    [SerializeField] private PlayerController player;
    [SerializeField] private LumberjacController lumberjac;
    #endregion

    #region UNITY_EVENTS
    
    void Update()
    {
        if (GameState == GameState.inGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Pause == false)
                {
                    ObPause.SetActive(true);
                    Pause = true;

                    Time.timeScale = 0;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else if (Pause == true)
                {
                    Restart();
                }
            }
            if (player.CurrentLife <= 0)
            {
                SceneManager.LoadScene(5);
            }
            if (lumberjac.CurrentLife <= 0)
            {
                SceneManager.LoadScene(4);
            }
        }
    }
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
    }
    #endregion

    #region ACTIVE_MENU
    public void Level_Start(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        ObPause.SetActive(false);
        Pause = false;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void GoToMenu(string menuName)
    {
        SceneManager.LoadScene(menuName);
    }
    #endregion
}
