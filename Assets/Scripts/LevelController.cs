using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null; // instance - щоб був доступ в усіх класах
    private int sceneIndex;
    private int levelComplete;

    public GameObject congratulatonsUI;

    private Character target;

    private void Awake()
    {
        if (!target) target = FindObjectOfType<Character>();
    }


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
        target.PlayAudioCongratulations();
        Time.timeScale = 0.5F;
        target.Rigidbody.AddForce(transform.up * 12.0F, ForceMode2D.Impulse);
        target.Rigidbody.AddForce(transform.up * 12.0F, ForceMode2D.Impulse);

        if (sceneIndex == 3)
        {
            Invoke("LoadMainMenu", 1F);
        } 
        else {
            if (levelComplete < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            }


            Invoke("ShowUI", 1F);

            //congratulatonsUI.SetActive(true);

            //Invoke("NextLevel", 1F);
        }
    }

    private void ShowUI()
    {
        Time.timeScale = 0F;
        congratulatonsUI.SetActive(true);
    }

    public void NextLevel()
    {
        Time.timeScale = 1F;
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1F;
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1F;
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
