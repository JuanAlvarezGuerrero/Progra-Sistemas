using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Pause : MonoBehaviour
{
    #region PUBLIC_PARAMETERS
    public GameObject Object_Pause;
    public bool Pause = false;

    #endregion

    #region UNITY_METHODS
    void Start()
    {
        Time.timeScale = 1.0f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause == false)
            {
                Object_Pause.SetActive(true);
                Pause = true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Pause == true)
            {
                Resume();
            }
        }
    }
    #endregion

    #region METHODS
    public void Resume()
    {
        Object_Pause.SetActive(false);
        Pause = false;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void GoToMenu(string nameMenu)
    {
        SceneManager.LoadScene(nameMenu);
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
   
    #endregion
}
