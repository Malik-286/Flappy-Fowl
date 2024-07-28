using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{

    [SerializeField] int selectedPrefeb;
    [SerializeField] GameObject[] Prefebs;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameWinPanel;
      
    
     [SerializeField] TextMeshProUGUI gamePlayScoreText;
 


    GameObject player;
    ScoreManager scoreManager;



    void Start()
    {
        selectedPrefeb = PlayerPrefs.GetInt("SelectedSkin");

        gameOverPanel.gameObject.SetActive(false);
        gameWinPanel.SetActive(false);
        scoreManager = FindObjectOfType<ScoreManager>();
   
    
        player = Instantiate(Prefebs[selectedPrefeb], SpawnPoint.transform.position, Quaternion.identity);
        player.SetActive(true);
 
    }

    void Update()
    {
        UpdateSpawnPointPosition();
        gamePlayScoreText.text = scoreManager.GetGamePlayScore().ToString("0");
 
          
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
}
