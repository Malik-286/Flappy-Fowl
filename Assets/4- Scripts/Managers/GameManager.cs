using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singelton<GameManager>
{

 
    public string currentLevel;

     protected override void Awake()
    {
        base.Awake();
        
       
    }
    public string GetCurrentScene()
    {
        return currentLevel;
    }

    void Update()
    {
        currentLevel = PlayerPrefs.GetString("CurrentLevelKey");
    }


    public void StartGame()
    {
        ScoreManager.GetInstance().ResetGamePlayScore();
        if (string.IsNullOrEmpty(currentLevel))
        {
             SceneManager.LoadScene(1);
        }
        else
        {
             SceneManager.LoadScene(currentLevel);
        }
       
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;      
        SceneManager.LoadScene(currentSceneIndex);
         Debug.Log("Loading Scene " + currentLevel);
         
    }

    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    
    
}
