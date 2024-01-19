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
        if(ScoreManager.GetInstance() != null)
        {
            gamePlayScoreText.text = ScoreManager.GetInstance().GetGamePlayScore().ToString();
            totalScoreText.text = ScoreManager.GetInstance().GetTotalScore().ToString();

        }
    }

    public void GoToMainMenu()
    {
        if (ScoreManager.GetInstance() != null)
        {
            ScoreManager.GetInstance().ResetGamePlayScore();
        }
            
           SceneManager.LoadScene("Main Menu");

    }

    public void PlayAgain()
    {
        
            ScoreManager.GetInstance().ResetGamePlayScore();        
            GameManager.GetInstance().RestartGame(); 
         
    }

    public void LoadNextNevel()
    {
        ScoreManager.GetInstance().ResetGamePlayScore();
        int CurrentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = CurrentLevelIndex + 1;
        SceneManager.LoadScene(nextLevelIndex);
    }
}
