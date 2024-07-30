using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
 
public class MainMenuUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject storePanel;
    [SerializeField] GameObject purchaseFailedPanel;
 
    [SerializeField] GameObject restorepurchaseButton;
    [SerializeField] AudioClip touchSFX;




  
   

    void Start()
    {

         settingsPanel.SetActive(false);
         purchaseFailedPanel.SetActive(false);
         storePanel.SetActive(false);
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
        if(AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlaySingleShotAudio(touchSFX, 1.0f);
        }
    }

    void Update()
    {
        if(ScoreManager.GetInstance() != null)
        {
            currentScoreText.text = ScoreManager.GetInstance().GetTotalScore().ToString();
        }
    }
    
    public void StartGame()
    {
        if(GameManager.GetInstance() != null)
        {
            PlayTouchAudio();
            GameManager.GetInstance().StartGame();
         }
        
     }

    

 
}
