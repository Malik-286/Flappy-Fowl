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
        //WorkingIndex = Index;
        Debug.LogError("hi " + Index);

        if (Index == 0)
        {
            this.gameObject.transform.parent.gameObject.SetActive(false);
            Time.timeScale = 1;
            if (FowlMovement.Instance)
            {
                FowlMovement.Instance.MoveUp();
                FowlMovement.Instance.MoveUp();
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