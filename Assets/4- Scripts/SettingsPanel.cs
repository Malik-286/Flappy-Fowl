using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class SettingsPanel : MonoBehaviour
{

     [SerializeField] TextMeshProUGUI appVersionText;
    [SerializeField] Slider audioSwitchSlider;

  
    [SerializeField] string[] socialMediaAccountsURLS;

     void Awake()
    {
         appVersionText.text = Application.version;
    }

    
    public void MuteAndUnMuteSound()
    {
        if(AudioManager.GetInstance() != null)
        {
            if(audioSwitchSlider.value == 1)
            {
                AudioManager.GetInstance().audioSource.mute = false;
             }
            else if(audioSwitchSlider.value == 0) 
            {
                AudioManager.GetInstance().audioSource.mute = true;
             }
        }
    }

   
 
     

   
    public void OpenSocialMediaAccount(int urlNumber)
    {
        Application.OpenURL(socialMediaAccountsURLS[urlNumber]);
    }
     
}
