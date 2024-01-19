using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data  
{
    public int totalScore;
 
    public Data(ScoreManager scoreManager )
    {
        this.totalScore = scoreManager.GetTotalScore();
     }  
    
     

    
}
