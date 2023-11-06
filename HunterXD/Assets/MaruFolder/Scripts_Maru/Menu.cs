using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    #region PUBLIC_PARAMETERS
    public GameObject ObPause;
    public bool Pause = true;
    #endregion

    #region UNITY_EVENTS
    void Update()
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
    }
    void Start()
    {
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
