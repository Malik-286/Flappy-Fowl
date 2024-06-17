using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMisc : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    private void Start()
    {
        rotateSpeed = Random.Range(-0.1f, 0.1f);
    }
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }
}
