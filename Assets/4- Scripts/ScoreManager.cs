using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public  class ScoreManager : Singelton<ScoreManager>
{
 
    public int totalScore;
    public int gamePlayScore;

    protected override void Awake()
    {
         base.Awake();
         LoadCurrencyData();
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
    }
    public void ResetTotalScore()
    {
        totalScore = 0;
        SaveCurrencyData() ;
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

