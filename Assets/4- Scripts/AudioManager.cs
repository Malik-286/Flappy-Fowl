using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [HideInInspector]
    public AudioSource audioSource;

    [SerializeField] Image imageComponent;
    [SerializeField] Sprite activeMusicImage;
    [SerializeField] Sprite deActiveMusicImage;
 
    void Start()
    {
        

        if (instance != null && instance != this)
        { 
           Destroy( this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
          
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
