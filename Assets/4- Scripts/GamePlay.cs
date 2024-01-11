using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlay : MonoBehaviour
{

    [SerializeField] GameObject[] Prefebs;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] TextMeshProUGUI gamePlayScoreText;
 

    GameObject player;
    ScoreManager scoreManager;
  
    
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();    
        int selectedPrefeb = PlayerPrefs.GetInt("SC");
        Debug.Log(selectedPrefeb);
        player = Instantiate(Prefebs[selectedPrefeb], SpawnPoint.transform.position, Quaternion.identity);

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

}
