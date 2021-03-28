using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlSceneAndMenu : MonoBehaviour
{
    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public GameObject buttonsLevels;

    public Button FirstLevelBtn;
    public Button SecondLevelBtn;
    public Button ThirdLevelBtn;
    private int levelComplete;





    // Start is called before the first frame update
    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        SecondLevelBtn.interactable = false;
        ThirdLevelBtn.interactable = false;

        switch (levelComplete)
        {
            case 1:
                SecondLevelBtn.interactable = true;
                break;

            case 2:
                SecondLevelBtn.interactable = true;
                ThirdLevelBtn.interactable = true;
                break; 
        }
    }

    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Reset()
    {
        SecondLevelBtn.interactable = false;
        ThirdLevelBtn.interactable = false;

        PlayerPrefs.DeleteKey("LevelComplete");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLevels()
    {
        buttonsLevels.SetActive(true);
        buttonsMenu.SetActive(false);
    }

    public void ShowExitButtons()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(true);
    }

    public void BackToMenu()
    {
        buttonsMenu.SetActive(true);
        buttonsExit.SetActive(false);
        buttonsLevels.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadNewGameScene()
    {
        
        //SceneManager.LoadScene("Game", LoadSceneMode.Additive);
        SceneManager.LoadScene("Level1");
        //Application.LoadLevel("Game");
    }


}
