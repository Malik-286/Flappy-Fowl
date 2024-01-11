using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject shopPanel;

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

    }

    public void PlayTouchAudio()
    {
       audioManager.PlaySingleShotAudio(touchSFX, 1.0f);
    }

    void Update()
    {
        currentScoreText.text = scoreManager.GetCurrentScore().ToString();
    }
    
    public void StartGame()
    {
        gameManager.StartGame();
    }

   

 
}
