using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField] string currentSavedScene;

    void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    public string GetCurrentSavedScene()
    {
        return currentSavedScene;
    }
    public void StartGame()
    {
             
        if(string.IsNullOrEmpty(currentSavedScene))
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
