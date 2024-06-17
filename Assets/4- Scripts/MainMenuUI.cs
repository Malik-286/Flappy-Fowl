using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
 
public class MainMenuUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] GameObject settingsPanel;
     [SerializeField] GameObject skinsPanel;
    [SerializeField] GameObject purchaseFailedPanel;
 
    [SerializeField] GameObject restorepurchaseButton;



    [SerializeField] AudioClip touchSFX;




    ScoreManager scoreManager;
    GameManager gameManager;

   

    void Start()
    {

        scoreManager = FindObjectOfType<ScoreManager>();
        gameManager = FindObjectOfType<GameManager>();
        settingsPanel.SetActive(false);
        purchaseFailedPanel.SetActive(false);
         skinsPanel.SetActive(false);
         FixRestorePurchaseButton();
  
    }

    void FixRestorePurchaseButton()
    {

        if(Application.platform != RuntimePlatform.IPhonePlayer)
        {
            restorepurchaseButton.SetActive(false);
        }else  
        {
            restorepurchaseButton.SetActive(true);
        }
    }
   
    public void PlayTouchAudio()
    {
         AudioManager.GetInstance().PlaySingleShotAudio(touchSFX, 1.0f);
    }

    void Update()
    {
        currentScoreText.text = scoreManager.GetTotalScore().ToString();
    }
    
    public void StartGame()
    {
        gameManager.StartGame();
    }

    

 
}
