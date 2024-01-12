using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public  class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int totalScore;
    public int gamePlayScore;

    void Awake()
    {

        RunSingelton();
        LoadCurrencyData();
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

   
     
 
    public int GetGamePlayScore()
    {

        return gamePlayScore;
    }

    public void IncreaseGamePlayScore()
    {
        gamePlayScore++;
        SaveCurrencyData();
    }

    public int GetTotalScore()
    {
         return totalScore;
    }


    public void IncreaseCurrentScore()
    {
        totalScore += gamePlayScore;
        SaveCurrencyData();
     }

    public void ResetGamePlayScore()
    {
        gamePlayScore = 0;
        SaveCurrencyData();
    }

    public void SaveCurrencyData()
    {
        SaveSystem.SaveDate(this);
    }

    public void LoadCurrencyData()
    {
        Data data =  SaveSystem.LoadData();
        this.totalScore = data.totalScore;
    }

    
}

