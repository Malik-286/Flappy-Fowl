using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCage : MonoBehaviour
{

    [SerializeField] GameObject dustyWings;
    [SerializeField] SpriteRenderer cagedBirdSprite;
    [SerializeField]  ParticleSystem winParticles;
    [SerializeField]  AudioClip winSoundEffect;
    [SerializeField]  GameObject[]  enviornmentParticles;

    GamePlayUI gamePlayUI;

      void Start()
    {
        dustyWings.SetActive(false);
        gamePlayUI = FindObjectOfType<GamePlayUI>();
        cagedBirdSprite.enabled = false;
        winParticles.Pause();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fowl"))
        {
                        
            winParticles.Play();
            cagedBirdSprite.enabled = true;
            dustyWings.SetActive(true);
            cagedBirdSprite.sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            collision.gameObject.SetActive(false);
            AudioManager.instance.PlaySingleShotAudio(winSoundEffect, 1.5f);
            Invoke("EnableWinPanel", 1.5f);


        }
    }

    void EnableWinPanel()
    {
        gamePlayUI.ActivateGameWinPanel();

        foreach (GameObject particles in enviornmentParticles)
        {
            Destroy(particles);
        }
         
    }
}
