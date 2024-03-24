using System;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

public class AppOpenAdController : MonoBehaviour
{
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-1387627577986386/9891539480";  
#elif UNITY_IPHONE
        private string _adUnitId = "ca-app-pub-3940256099942544/5575463023";  
#else
        private string _adUnitId = "unused";
#endif

    private AppOpenAd appOpenAd;
    private DateTime _expireTime;

    public bool IsAdAvailable
    {
        get
        {
            return appOpenAd != null && appOpenAd.CanShowAd() && DateTime.Now < _expireTime;
        }
    }

      void Start()
    {
        if (PlayerPrefs.GetString("AdsStatusKey") == "disabled")
        {
            return;
        }
        else
        {
            MobileAds.Initialize((InitializationStatus initStatus) =>  { });
            LoadAppOpenAd();
        }
    }

    public void LoadAppOpenAd()
    {
        if (appOpenAd != null)
        {
            appOpenAd.Destroy();
            appOpenAd = null;
        }

        Debug.Log("Loading the app open ad.");

        var adRequest = new AdRequest();

        AppOpenAd.Load(_adUnitId, adRequest, (AppOpenAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogError("App open ad failed to load an ad with error: " + error);
                return;
            }

            Debug.Log("App open ad loaded with response: " + ad.GetResponseInfo());

            _expireTime = DateTime.Now + TimeSpan.FromHours(4);
            appOpenAd = ad;
            ShowAppOpenAd();
            RegisterEventHandlers(ad);
        });
    }

    private void RegisterEventHandlers(AppOpenAd ad)
    {
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("App open ad paid {0} {1}.", adValue.Value, adValue.CurrencyCode));
        };
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("App open ad recorded an impression.");
        };
        ad.OnAdClicked += () =>
        {
            Debug.Log("App open ad was clicked.");
        };
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("App open ad full screen content opened.");
        };
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("App open ad full screen content closed.");
            LoadAppOpenAd(); // Preload the next ad
        };
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("App open ad failed to open full screen content with error: " + error);
            LoadAppOpenAd(); // Preload the next ad
        };
    }

    public void ShowAppOpenAd()
    {
        if (appOpenAd != null && appOpenAd.CanShowAd())
        {
            Debug.Log("Showing app open ad.");
            appOpenAd.Show();
        }
        else
        {
            Debug.LogError("App open ad is not ready yet.");
        }
    }

    private void Awake()
    {
        AppStateEventNotifier.AppStateChanged += OnAppStateChanged;
    }

    private void OnDestroy()
    {
        AppStateEventNotifier.AppStateChanged -= OnAppStateChanged;
    }

    private void OnAppStateChanged(AppState state)
    {
        Debug.Log("App State changed to: " + state);

        if (state == AppState.Foreground && IsAdAvailable)
        {
            ShowAppOpenAd();
        }
    }
}
