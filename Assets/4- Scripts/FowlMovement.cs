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
    GamePlayUI gamePlayUI;
 
    void Start()
    {
        rb_fowl = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
        gamePlayUI = FindObjectOfType<GamePlayUI>();
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
            scoreManager.totalScore += scoreManager.GetGamePlayScore();
            if (AudioManager.instance != null)
            {               
                AudioManager.instance.PlaySingleShotAudio(collisionSFX, 1.8f);
            }
               gamePlayUI.ActivateGameOverPanel();
               this.gameObject.SetActive(false);
 
        }

    }

  


}
