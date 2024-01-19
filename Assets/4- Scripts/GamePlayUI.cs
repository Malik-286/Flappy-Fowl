using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayUI : MonoBehaviour
{

    [SerializeField] GameObject[] Prefebs;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameWinPanel;
    [SerializeField] int numberofFowlsToPass;
    
    
     [SerializeField] TextMeshProUGUI gamePlayScoreText;
     [SerializeField] TextMeshProUGUI fowlsToPassText;



    GameObject player;
    ScoreManager scoreManager;
  
    
    void Start()
    {
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        scoreManager = FindObjectOfType<ScoreManager>();    
        int selectedPrefeb = PlayerPrefs.GetInt("SelectedSkin");
        player = Instantiate(Prefebs[selectedPrefeb], SpawnPoint.transform.position, Quaternion.identity);

    }

    void Update()
    {
        UpdateSpawnPointPosition();
        gamePlayScoreText.text = scoreManager.GetGamePlayScore().ToString("0");
        fowlsToPassText.text = numberofFowlsToPass.ToString("Fowls Left: "+numberofFowlsToPass);

          
    }

   public void DecreaseNumberOfFowls()
    {
       numberofFowlsToPass--;
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
