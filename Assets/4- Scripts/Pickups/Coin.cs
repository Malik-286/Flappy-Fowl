using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] AudioClip coinSoundEffect;



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fowl"))
        {
            if(AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(coinSoundEffect, 1.0f);
            }
            if(ScoreManager.GetInstance() != null)
            {
                ScoreManager.GetInstance().IncreaseRewardScore(1);
                ScoreManager.GetInstance().SaveCurrencyData();
            }           
               Destroy(gameObject);
        } 

    }
}
