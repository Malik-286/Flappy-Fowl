using hardartcore.CasualGUI;
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
            Time.timeScale = 1.0f;
            PlayTouchAudio();
            GameManager.GetInstance().StartGame();
         }
        
     }

    public void RateUs()
    {
        string playStoreUrl = "https://play.google.com/store/apps/details?id=com.AspirePlay.FlappyFowl&pcampaignid=web_share";
        Application.OpenURL(playStoreUrl);

    }

    public void ActivateStorePanel()
    {
        Time.timeScale = 1.0f;
        PlayTouchAudio();
        storePanel.gameObject.GetComponent<Dialog>().ShowDialog();

        if(Adsmanager.Instance.Rewarded)
        {
            Adsmanager.Instance.Rewarded.LoadAd();
        }
    }

    public void ActivateSettingsPanel()
    {
        Time.timeScale = 1.0f;
        PlayTouchAudio();
        settingsPanel.gameObject.GetComponent<Dialog>().ShowDialog();
    }

 

}
