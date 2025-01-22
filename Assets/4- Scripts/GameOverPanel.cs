using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{

    public TextMeshProUGUI gamePlayScoreText;
    public TextMeshProUGUI totalScoreText;


    void Start()
    {
        //if (Adsmanager.Instance)
        //{
        //    Adsmanager.Instance.Interstitial.LoadAd(); //HaiderADSRemoving
        //}         
    }

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
      
        PlayerPrefs.SetString("CurrentLevelKey", SceneManager.GetActiveScene().name);

        if (ScoreManager.GetInstance() != null)
        {
            ScoreManager.GetInstance().ResetGamePlayScore();
        }
            SceneManager.LoadScene("Main Menu");

    }

    public void PlayAgain()
    {
        //if (Adsmanager.Instance)
        //{
        //    Adsmanager.Instance.ShowIntersitial(); //HaiderADSRemoving
        //}
        if (ScoreManager.GetInstance())
        {
            ScoreManager.GetInstance().ResetGamePlayScore();
        }
          
        if (GameManager.GetInstance() != null)
        {
            GameManager.GetInstance().RestartGame();        
        }
             
         
    }

    public void LoadNextNevel()
    {
        //if (Adsmanager.Instance)
        //{
        //    Adsmanager.Instance.ShowIntersitial(); //HaiderADSRemoving
        //}

        PlayerPrefs.SetString("CurrentLevelKey", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save(); // Ensure the PlayerPrefs are saved


        ScoreManager.GetInstance().ResetGamePlayScore();

        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;

        Debug.Log("Current Level Index: " + currentLevelIndex);
        Debug.Log("Next Level Index: " + nextLevelIndex);
        Debug.Log("Total Levels: " + SceneManager.sceneCountInBuildSettings);

        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            // Load Random Level in the game.
            SceneManager.LoadScene("Main Menu");
        }
    }

}
