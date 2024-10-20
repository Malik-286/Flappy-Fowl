using System.Collections;
using UnityEngine;
 
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
    SpriteRenderer spriteRenderer;

    [SerializeField] Color defaultColour = new Color(255, 255, 255, 255);
    [SerializeField] Color damageColour = Color.red;
 
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
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color =  defaultColour;
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
        rb_fowl.linearVelocity = new Vector2(0, upForce * Time.deltaTime);      
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

   
        if (collision.gameObject.CompareTag("Pipes"))
        {
            if (ScoreManager.GetInstance() != null)
            {
                ScoreManager.GetInstance().totalScore += ScoreManager.GetInstance().GetGamePlayScore();
                ScoreManager.GetInstance().SaveCurrencyData();
            }
            DisablePlayerCollider();

            spriteRenderer.color = damageColour;

            StartCoroutine(EnablePlayerCollider());
            StartCoroutine(ResetPlayerColour());


            gamePlayUI.ActivateGameOverPanel();
            if (AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(collisionSFX, 1.8f);
            }
            Invoke(nameof(ChangeTimeScale), 0.1f);
            //this.gameObject.SetActive(false); 
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            if (ScoreManager.GetInstance() != null)
            {
                ScoreManager.GetInstance().totalScore += ScoreManager.GetInstance().GetGamePlayScore();
                ScoreManager.GetInstance().SaveCurrencyData();
            }
            DisablePlayerCollider();

            spriteRenderer.color = damageColour;

          //  StartCoroutine(EnablePlayerCollider());
         //   StartCoroutine(ResetPlayerColour());


            gamePlayUI.ActivateGrassCollisionGameOverPanel();
            if (AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(collisionSFX, 1.8f);
            }
            Invoke(nameof(ChangeTimeScale), 0.1f);
         
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

    public IEnumerator ResetPlayerColour()
    {
        Debug.Log("Starting ResetPlayerColour Coroutine");

        yield return new WaitForSeconds(0.25f);
        spriteRenderer.color = defaultColour;
        Debug.Log("Set color to defaultColour");

        yield return new WaitForSeconds(0.25f);
        spriteRenderer.color = damageColour;
        Debug.Log("Set color to damageColour");

        yield return new WaitForSeconds(0.25f);
        spriteRenderer.color = defaultColour;
        Debug.Log("Set color to defaultColour");

        yield return new WaitForSeconds(0.25f);
        spriteRenderer.color = damageColour;
        Debug.Log("Set color to damageColour");

        yield return new WaitForSeconds(0.25f);
        spriteRenderer.color = defaultColour;
        Debug.Log("Set color to defaultColour");

        Debug.Log("Finished ResetPlayerColour Coroutine");
    }






}
