using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class FowlMovement : MonoBehaviour
{

    public static FowlMovement Instance;

    [Header("Physics Variables")]

    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float upForce = 150f;

    [Header("Audio Variables")]

    [SerializeField] AudioClip touchSFX;
    [SerializeField] AudioClip collisionSFX;
    [SerializeField] AudioClip passSFX;


     


    Rigidbody2D rb_fowl;
    Vector2 UpForce = new Vector2(0f, 5f);
     GamePlayUI gamePlayUI;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        rb_fowl = GetComponent<Rigidbody2D>();
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
            if(AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(touchSFX, 2f);
            }         
              MoveUp();
        }
    }

    public void MoveForward()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    public void MoveUp()
    {
        rb_fowl.velocity = new Vector2(0, upForce * Time.deltaTime);      
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pass"))
        {
   
            if (AudioManager.GetInstance() != null)
            {
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().IncreaseGamePlayScore();
                 }
                      
                 AudioManager.GetInstance().PlaySingleShotAudio(passSFX, 2.0f);
             }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.CompareTag("Pipes")  || collision.gameObject.CompareTag("Ground"))
        {
            ScoreManager.GetInstance().totalScore += ScoreManager.GetInstance().GetGamePlayScore();
            DisablePlayerCollider();
            StartCoroutine(EnablePlayerCollider());
            ScoreManager.GetInstance().SaveCurrencyData();
            gamePlayUI.ActivateGameOverPanel();
            if (AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(collisionSFX, 1.8f);
            }
            Invoke(nameof(ChangeTimeScale), 0.1f);
            //this.gameObject.SetActive(false); 
        }

    }

    public void ChangeTimeScale()
    {
        Time.timeScale = 0;
    }


    public void DisablePlayerCollider()
    {
        if(this.gameObject != null)
        {
             gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

   
    IEnumerator EnablePlayerCollider()
    {
        float timeToEnableCollider = 2.0f;
        yield return new WaitForSeconds(timeToEnableCollider);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;

    }




}
