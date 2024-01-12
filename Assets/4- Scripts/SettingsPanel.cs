using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class SettingsPanel : MonoBehaviour
{

    [SerializeField] Toggle audioToggle;
    void Awake()
    {
        FixToggleTick();
    }
    public void MuteAndUnMuteSound(Toggle toggle)
    {
        if(AudioManager.instance != null)
        {
            if(toggle.isOn)
            {
                AudioManager.instance.audioSource.mute = false;    
            }
            else if(!toggle.isOn) 
            {
                AudioManager.instance.audioSource.mute = true;
            }
        }
    }

    void FixToggleTick()
    {
        if(AudioManager.instance.audioSource.mute == false)
        {
            audioToggle.isOn = true;
        }
        else if(AudioManager.instance.audioSource.mute == true)
        {
            audioToggle.isOn = false;
        }
    }
     
}
