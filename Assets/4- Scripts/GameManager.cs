using System.Collections;
using System.Collections.Generic;
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
}
