using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] AudioClip coinSoundEffect;


 //   [Header("Coin Move Animation")]
  //  public bool moveCoin = false;
  //  [SerializeField] float moveSpeed = 5.0f;
  //  [SerializeField] GameObject moveTargetPosition;

    void Start()
    {
     //   moveCoin = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fowl"))
        {
         //   moveCoin = true;
            if (AudioManager.GetInstance() != null)
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

    /* 
    void Update()
    {
        MoveCoin();
    }
    void MoveCoin()
    {
        if (moveCoin)
        {
            float step = moveSpeed * Time.deltaTime; // Calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, moveTargetPosition.transform.position, step);

            // Check if the coin has reached the target position
            if (Vector3.Distance(transform.position, moveTargetPosition.transform.position) < 0.001f)
            {
                moveCoin = false; // Stop moving the coin
            }
        }
    }
    */
}
