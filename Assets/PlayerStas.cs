using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStas : MonoBehaviour
{
    public Transform player;      // Reference to the player's position
    public Transform endPoint;    // Reference to the end point's position
    public Image distanceFiller;  // Reference to the UI Image for filling

    private float maxDistance;    // Maximum distance for full fill



    private void Awake()
    {
        //Track Player
        player = GamePlayUI.instance.player.transform;
    }
    void Start()
    {
        // Calculate the initial max distance (could be the starting distance)
        maxDistance = Vector3.Distance(player.position, endPoint.position);
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the current distance
            float currentDistance = Vector3.Distance(player.position, endPoint.position);

            // Calculate the fill amount (1 when at the start, 0 when at the end)
            float fillAmount = Mathf.Clamp01(currentDistance / maxDistance);

            // Update the Image's fill amount
            distanceFiller.fillAmount = fillAmount;
        }
    }
}
