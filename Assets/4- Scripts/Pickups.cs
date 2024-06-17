using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    [SerializeField] AudioClip[] pickupsSFX;



    AudioManager audioManager;
    ScoreManager scoreManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

 



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fowl"))
        {
             
            audioManager.PlaySingleShotAudio(pickupsSFX[Random.Range(0, pickupsSFX.Length)], 1.2f);
            scoreManager.IncreaseRewardScore(5);
             Destroy(gameObject);
        }
 
    }
}
