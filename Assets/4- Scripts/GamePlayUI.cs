using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{

    [SerializeField] GameObject[] Prefebs;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameWinPanel;
    [SerializeField] TextMeshProUGUI gameLevelNoText;
     
    
     [SerializeField] TextMeshProUGUI gamePlayScoreText;
 


    GameObject player;
    ScoreManager scoreManager;
  
    
    void Start()
    {
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        scoreManager = FindObjectOfType<ScoreManager>();    
        int selectedPrefeb = PlayerPrefs.GetInt("SelectedSkin");
        player = Instantiate(Prefebs[selectedPrefeb], SpawnPoint.transform.position, Quaternion.identity);
        gameLevelNoText.text = SceneManager.GetActiveScene().name;

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
