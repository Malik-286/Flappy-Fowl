using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public  class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

   
      void Awake()
    {
 
        RunSingelton();
    }

    void RunSingelton()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

    }

      void Start()
     {
        ResetGamePlayScore();
     }

    public int currentScore;
    public int gamePlayScore;
     
 
    public int GetGamePlayScore()
    {

        return gamePlayScore;
    }

    public void IncreaseGamePlayScore()
    {
        gamePlayScore++;
    }

    public int GetCurrentScore()
    {
         return currentScore;
    }


    public void IncreaseCurrentScore()
    {
         currentScore += gamePlayScore;
     }

    public void ResetGamePlayScore()
    {
        gamePlayScore = 0;
    }


    
}

