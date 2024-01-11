using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class FowlMovement : MonoBehaviour
{
    [Header("Physics Variables")]

    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float upForce = 150f;

    [Header("Audio Variables")]

    [SerializeField] AudioClip touchSFX;
    [SerializeField] AudioClip collisionSFX;
    [SerializeField] AudioClip passSFX;


     


    Rigidbody2D rb_fowl;
    Vector2 UpForce = new Vector2(0f, 5f);
    ScoreManager scoreManager;
 
    void Start()
    {
        rb_fowl = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
     }

    


    void Update()
    {

        DetectTouchInput();
        MoveForward();
    }

    void DetectTouchInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(AudioManager.instance != null)
            {
                AudioManager.instance.PlaySingleShotAudio(touchSFX, 2f);
            }         
              MoveUp();
        }
    }

    void MoveForward()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    void MoveUp()
    {
        rb_fowl.velocity = new Vector2(0, upForce * Time.deltaTime);      
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pass") == true)
        {
            Debug.Log("Passed");
  
            if (AudioManager.instance != null)
            {
                if (scoreManager != null)
                {
                    scoreManager.IncreaseGamePlayScore();
                }
                      
                 AudioManager.instance.PlaySingleShotAudio(passSFX, 2.0f);
             }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.CompareTag("Pipes")  || collision.gameObject.CompareTag("Ground") == true)
        {
               Debug.Log("Collided Detected...!");
            if (AudioManager.instance != null)
            {
                scoreManager.currentScore += scoreManager.GetGamePlayScore();
                AudioManager.instance.PlaySingleShotAudio(collisionSFX, 1.8f);
            }
               Invoke("FowlDeath", 0.30f);
 
        }

    }



    void FowlDeath()
    {
        scoreManager.ResetGamePlayScore();
        SceneManager.LoadScene("Main Menu");
       
    }

  

    


}
