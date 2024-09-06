using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Sample;

public class Adsmanager : MonoBehaviour
{
    [Header("Instance")]
    public static Adsmanager Instance;

    [Space(10f)]
    public Banner Banner;
    public InterstitialAdController Interstitial;
    public Rewarded Rewarded;

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
       DontDestroyOnLoad(this);

        ShowBanner();

    }

    #region Callings


    public void ShowBanner()
    {
        Banner.LoadAd();
    }
    public void ShowIntersitial()
    {
        Interstitial.ShowAd();
    }
    public void ShowRewardedVideoAd()
    {
        Rewarded.ShowRewardedAd();
    }
    #endregion


    // Update is called once per frame
    void Update()
    {
        
    }
}
