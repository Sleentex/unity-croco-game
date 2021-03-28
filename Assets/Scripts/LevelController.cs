using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null; // instance - щоб був доступ в усіх класах
    private int sceneIndex;
    private int levelComplete;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void IsEndGame()
    {
        if (sceneIndex == 3)
        {
            Invoke("LoadMainMenu", 1F);
        } 
        else {
            if (levelComplete < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            }
            Invoke("NextLevel", 1F);
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
