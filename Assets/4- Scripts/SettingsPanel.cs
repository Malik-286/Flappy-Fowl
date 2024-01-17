using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class SettingsPanel : MonoBehaviour
{

    [SerializeField] Toggle audioToggle;
    [SerializeField] TextMeshProUGUI soundOnOffText;
    [SerializeField] TextMeshProUGUI appVersionText;

    [SerializeField] string googlePlayStoreURL;
    [SerializeField] GameObject resetConfirmationPanel;

    [SerializeField] string[] socialMediaAccountsURLS;

     void Awake()
    {
        FixToggleTick();
        appVersionText.text = "game version "+ Application.version;
    }

    void Start()
    {
         resetConfirmationPanel.SetActive(false);
    }
    public void MuteAndUnMuteSound(Toggle toggle)
    {
        if(AudioManager.GetInstance() != null)
        {
            if(toggle.isOn)
            {
                AudioManager.GetInstance().audioSource.mute = false;
                soundOnOffText.text = "ON".ToUpper();
            }
            else if(!toggle.isOn) 
            {
                AudioManager.GetInstance().audioSource.mute = true;
                soundOnOffText.text = "OFF".ToUpper();
            }
        }
    }

    void FixToggleTick()
    {
        if(AudioManager.GetInstance() && audioToggle != null) 
        {
            if (AudioManager.GetInstance().audioSource.mute == false)
            {
                soundOnOffText.text = "ON".ToUpper();
                audioToggle.isOn = true;
                
            }
            else if (AudioManager.GetInstance().audioSource.mute == true)
            {
                soundOnOffText.text = "OFF".ToUpper();
                audioToggle.isOn = false;
                
            }
        }
        
    }

    public void RateUs()
    {
        Application.OpenURL(googlePlayStoreURL);
    }

     

    public void ActivateResetPanel()
    {
        resetConfirmationPanel.SetActive(true);
    }

    public void OpenSocialMediaAccount(int urlNumber)
    {
        Application.OpenURL(socialMediaAccountsURLS[urlNumber]);
    }
     
}
