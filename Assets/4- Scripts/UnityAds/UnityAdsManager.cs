using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsManager : MonoBehaviour, IUnityAdsInitializationListener
{

    public static UnityAdsManager instance;

    [SerializeField] UnityBannerAd Banner;
    [SerializeField] UnityInterstialAd Interstitial;

    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        InitializeAds();

        DontDestroyOnLoad(gameObject);
    }

    public void InitializeAds()
    {
#if UNITY_IOS
            _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }

    #region AdsCallings

    public void ShowBanner()
    {
        if (Banner != null)
        {
            Banner.ShowBannerAd();
        }
    }
    public void HideBanner()
    {
        if (Banner != null)
        {
            Banner.HideBannerAd();
        }
    }
    public void ShowInterstitial()
    {
        if (Interstitial != null)
        {
            Interstitial.ShowAd();
        }
    }
    #endregion

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
