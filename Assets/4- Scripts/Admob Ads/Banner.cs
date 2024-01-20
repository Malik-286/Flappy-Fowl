using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
using UnityEngine;

public class Banner : MonoBehaviour
{
    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-1387627577986386/8030925845";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  private string _adUnitId = "unused";
#endif


    BannerView bannerView;
    public void Start()
    {
        if (PlayerPrefs.GetString("AdsStatusKey") == "disabled")
        {
            return;
        }
        else
        {
            MobileAds.Initialize((InitializationStatus initStatus) =>
            {
            });

            CreateBannerView();
            LoadAd();
        }
         
     }

    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

         if (bannerView != null)
        {
            DestroyBannerView();
        }
 
          bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Bottom);


    }
    public void LoadAd()
    {
         if (bannerView == null)
        {
            CreateBannerView();
        }

         var adRequest = new AdRequest();

         Debug.Log("Loading banner ad.");
         bannerView.LoadAd(adRequest);

         ListenToAdEvents();
    }

 
    private void ListenToAdEvents()
    {
        // Raised when an ad is loaded into the banner view.
        bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
        };
        // Raised when the ad is estimated to have earned money.
        bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Banner view paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };
        // Raised when an ad opened full screen content.
        bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
        };
    }
 
    public void DestroyBannerView()
    {
        if (bannerView != null)
        {
            Debug.Log("Destroying banner view.");
            bannerView.Destroy();
            bannerView = null;
        }
    }
}