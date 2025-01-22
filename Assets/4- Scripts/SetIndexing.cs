using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIndexing : MonoBehaviour
{

    public static SetIndexing Instance;

    public int IndexNumber;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void AssignIndex()
    {
        //if (AdmobRewardedVideo.Instance)
        //{
        //    AdmobRewardedVideo.Instance.Index = IndexNumber;
        //}
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
