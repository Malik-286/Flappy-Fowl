using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : Singelton<AudioManager>
{
 
     public AudioSource audioSource;

    [SerializeField] Image imageComponent;
    [SerializeField] Sprite activeMusicImage;
    [SerializeField] Sprite deActiveMusicImage;


     protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }
    

    public void PlaySingleShotAudio(AudioClip singleShotAudio, float volume)
    {
        audioSource.PlayOneShot(singleShotAudio, volume);
    
    }

    

    public void ActivateGameAudio()
    {
        if (!audioSource.mute)
        {         
             audioSource.mute = true;
            imageComponent.sprite = deActiveMusicImage;
        }
        else if (audioSource.mute)
        {
             audioSource.mute = false;
            imageComponent.sprite = activeMusicImage;
        }
    
    
    }

     
     
}
