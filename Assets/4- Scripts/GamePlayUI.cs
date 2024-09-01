using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    //Instance
    public static GamePlayUI instance;

    public int selectedPrefeb;
    public GameObject[] Prefebs;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameWinPanel;
    public Image PlayerStatus;
    public GameObject player;
    ScoreManager scoreManager;   
    

     [SerializeField] TextMeshProUGUI gamePlayScoreText;
     [SerializeField] TextMeshProUGUI levelNameText;
 



    //Player Progress
    public Transform endPoint;    // Reference to the end point's position
    public Image distanceFiller;  // Reference to the UI Image for filling
    private float maxDistance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    void Start()
    {
        selectedPrefeb = PlayerPrefs.GetInt("SelectedSkin");

        gameOverPanel.gameObject.SetActive(false);
        gameWinPanel.SetActive(false);
        scoreManager = FindObjectOfType<ScoreManager>();
        UpdateLevelNameText();


        player = Instantiate(Prefebs[selectedPrefeb], SpawnPoint.transform.position, Quaternion.identity);
        player.SetActive(true);

        maxDistance = Vector3.Distance(player.transform.position, endPoint.position);

    }

    void Update()
    {
        UpdateSpawnPointPosition();
        if (scoreManager)
        {
        gamePlayScoreText.text = scoreManager.GetGamePlayScore().ToString("0");        
        }

        if (player != null)
        {
            // Calculate the current distance
            float currentDistance = Vector3.Distance(endPoint.position, player.transform.position);

            // Calculate the fill amount (1 when at the start, 0 when at the end)
            float fillAmount = Mathf.Clamp01(currentDistance / maxDistance);

            // Update the Image's fill amount
            distanceFiller.fillAmount = fillAmount;
        }

    }

  

    void UpdateSpawnPointPosition()
    {
        SpawnPoint.transform.position = player.transform.position;

    }

    public void ActivateGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void ActivateGameWinPanel()
    {
        gameWinPanel.SetActive(true);
    }

    void UpdateLevelNameText()
    {
        levelNameText.text = GameManager.GetInstance().GetCurrentSceneName();
    }

}
