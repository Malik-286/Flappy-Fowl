using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{

    public TextMeshProUGUI gamePlayScoreText;
    public TextMeshProUGUI totalScoreText;


    

     void FixedUpdate()
    {
        UpdateGameOverPanelScoreText();
    }

    void UpdateGameOverPanelScoreText()
    {
        if(ScoreManager.instance != null)
        {
            gamePlayScoreText.text = ScoreManager.instance.GetGamePlayScore().ToString();
            totalScoreText.text = ScoreManager.instance.GetTotalScore().ToString();

        }
    }

    public void GoToMainMenu()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetGamePlayScore();
        }
            
           SceneManager.LoadScene("Main Menu");

    }

    public void PlayAgain()
    {
        
            ScoreManager.instance.ResetGamePlayScore();        
            GameManager.instance.RestartGame(); 
         
    }

    public void LoadNextNevel()
    {
        int CurrentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = CurrentLevelIndex + 1;
        SceneManager.LoadScene(nextLevelIndex);
    }
}
