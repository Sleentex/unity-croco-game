using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject panelExit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        panelExit.SetActive(false);
        Time.timeScale = 1F;
        GameIsPaused = false; 
    }


    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        panelExit.SetActive(false);

        Time.timeScale = 0F; // екран зупиняється, від 0 до 1, 1 це норм хід ігри
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1F;
        SceneManager.LoadScene("Menu");
    }

    public void ShowExitButtons()
    {
        pauseMenuUI.SetActive(false);
        panelExit.SetActive(true);
    }

    public void BackToMenu()
    {
        pauseMenuUI.SetActive(true);
        panelExit.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1F;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
}
