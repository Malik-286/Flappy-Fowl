using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPosition : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float fixedY;

    void Start()
    {
        // Store the initial Y position of the GameObject
        fixedY = transform.position.y;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Update only the X position of the GameObject, keeping the Y position fixed
            transform.position = new Vector3(target.position.x, fixedY, transform.position.z);
        }
    }
}
