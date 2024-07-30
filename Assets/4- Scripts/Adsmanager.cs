using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adsmanager : MonoBehaviour
{
    [Header("Instance")]
    public static Adsmanager Instance;

    [Space(10f)]
    public Banner Banner;
    public Interstitial Interstitial;
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
        Banner.CreateBannerView();
    }
    public void ShowIntersitial()
    {
        Interstitial.ShowInterstitialAd();
    }
    public void ShowRewardedVideoAd()
    {
        Rewarded.LoadRewardedAd();
        Rewarded.ShowRewardedAd();
    }
    #endregion


    // Update is called once per frame
    void Update()
    {
        
    }
}
