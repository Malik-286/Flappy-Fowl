using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AdmobRewardedVideo : MonoBehaviour
{
    public static AdmobRewardedVideo Instance;
    public int Index;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #region Give Reward

    public void RewardAfterAd()
    {
        if (Index == 0)
        {
            this.gameObject.transform.parent.gameObject.SetActive(false);
           // Time.timeScale = 1;
            if (FowlMovement.Instance)
            {
                FowlMovement.Instance.MoveUp();   // first call to move up
                FowlMovement.Instance.MoveUp();    // second call to move up
   
            }
        }
        if (Index == 1)
        {
            print("Come");
            if (PremiumSkins.Instance)
            {
                print("Skin Number purchased" + 0);
                PremiumSkins.Instance.UnlockPremiumSkins(0);
            }
        }
        if (Index == 2)
        {
            if (PremiumSkins.Instance)
            {
                print("Skin Number purchased" + 1);
                PremiumSkins.Instance.UnlockPremiumSkins(1);
            }
        }
        if (Index == 3)
        {
            print("Come");
            if (PremiumSkins.Instance)
            {
                print("Skin Number purchased" + 2);
                PremiumSkins.Instance.UnlockPremiumSkins(2);
            }
        }
        if (Index == 4)
        {
            if (PremiumSkins.Instance)
            {
                print("Skin Number purchased" + 3);
                PremiumSkins.Instance.UnlockPremiumSkins(3);
            }
        }
        if (Index == 5)
        {
            print("Come");
            if (PremiumSkins.Instance)
            {
                print("Skin Number purchased" + 4);
                PremiumSkins.Instance.UnlockPremiumSkins(4);
            }
        }
        if (Index == 6)
        {
            if (PremiumSkins.Instance)
            {
                print("Skin Number purchased" + 5);
                PremiumSkins.Instance.UnlockPremiumSkins(5);
            }
        }
    }
    #endregion
    public void ShowRewardedVideo()
    {
        if (Adsmanager.Instance)
         Adsmanager.Instance.ShowRewardedVideoAd();
    }
    public void Show_RewardedInterstitial_Video()
    {
       // if (AdsManager.instance)
          //  AdsManager.instance.RewardedInterstitial.ShowAd(this);
    }


}