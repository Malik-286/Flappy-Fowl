using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class SettingsPanel : MonoBehaviour
{

    [SerializeField] Slider audioSlider;
    [SerializeField] TextMeshProUGUI appVersionText;

    [SerializeField] string googlePlayStoreURL;
 
    [SerializeField] string[] socialMediaAccountsURLS;

     void Awake()
    {
         appVersionText.text = Application.version;
    }

    
    public void MuteAndUnMuteSound(Toggle toggle)
    {
        if(AudioManager.GetInstance() != null)
        {
            if(toggle.isOn)
            {
                AudioManager.GetInstance().audioSource.mute = false;
             }
            else if(!toggle.isOn) 
            {
                AudioManager.GetInstance().audioSource.mute = true;
             }
        }
    }

   

    public void RateUs()
    {
        Application.OpenURL(googlePlayStoreURL);
    }

     

   
    public void OpenSocialMediaAccount(int urlNumber)
    {
        Application.OpenURL(socialMediaAccountsURLS[urlNumber]);
    }
     
}
