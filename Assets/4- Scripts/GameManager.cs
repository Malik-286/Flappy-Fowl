using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singelton<GameManager>
{

     

    [SerializeField] string currentSavedScene;

     protected override void Awake()
    {
        base.Awake();   
       
    }
    public string GetCurrentSavedScene()
    {
        return currentSavedScene;
    }
    public void StartGame()
    {
        ScoreManager.GetInstance().ResetGamePlayScore();
        if (string.IsNullOrEmpty(currentSavedScene))
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(currentSavedScene);
        }
       
    }

    public void RestartGame()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}
