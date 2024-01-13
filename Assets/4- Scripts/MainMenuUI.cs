using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
 
public class MainMenuUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject resetPanel;


    [SerializeField] AudioClip touchSFX;




    ScoreManager scoreManager;
    AudioManager audioManager;
    GameManager gameManager;
    void Start()
    {

        scoreManager = FindObjectOfType<ScoreManager>();
        audioManager = FindObjectOfType<AudioManager>(); 
        gameManager = FindObjectOfType<GameManager>();
        settingsPanel.SetActive(false);
        shopPanel.SetActive(false);
        resetPanel.SetActive(false);

    }

    public void PlayTouchAudio()
    {
       audioManager.PlaySingleShotAudio(touchSFX, 1.0f);
    }

    void Update()
    {
        currentScoreText.text = scoreManager.GetTotalScore().ToString();
    }
    
    public void StartGame()
    {
        gameManager.StartGame();
    }

   
        public void ResetGame()
        {
            if (scoreManager != null)
            {
                scoreManager.ResetTotalScore();
            }

        }
    
   

 
}
