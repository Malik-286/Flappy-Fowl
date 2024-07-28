using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{

    public TextMeshProUGUI gamePlayScoreText;
    public TextMeshProUGUI totalScoreText;


    Interstitial interstitialAd;

    void Start()
    {
        interstitialAd = FindObjectOfType<Interstitial>();
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
        if(interstitialAd != null)
        {
            interstitialAd.LoadInterstitialAd();
        }
        PlayerPrefs.SetString("CurrentLevelKey", SceneManager.GetActiveScene().name);

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
        if (interstitialAd != null)
        {
            interstitialAd.LoadInterstitialAd();
        }
        PlayerPrefs.SetString("CurrentLevelKey", SceneManager.GetActiveScene().name);
        ScoreManager.GetInstance().ResetGamePlayScore();

        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;

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
