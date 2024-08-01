using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Store : MonoBehaviour
{

     [SerializeField] GameObject purchaseFailedPanel;
     [SerializeField] AudioClip purchaseSoundEffect;



    const string removeAds_ProductID = "com.aspireplay.flappyfowl.removeads";
    const string trophies_Pack_01 = "com.aspireplay.flappyfowl.300trophies";
    const string trophies_Pack_02 = "com.aspireplay.flappyfowl.1000trophies";
    const string trophies_Pack_03 = "com.aspireplay.flappyfowl.5000trophies";





    [Header("Ads Status")]
    public string adsStaus = "enabled";

    void Awake()
    {      
        purchaseFailedPanel.SetActive(false);
        adsStaus = PlayerPrefs.GetString("AdsStatusKey");
    }

    

    public void OnPurchaseComplete(Product product)
    {

         if(product.definition.id == removeAds_ProductID)
        {
            adsStaus = "disabled";
            PlayerPrefs.SetString("AdsStatusKey", adsStaus);

        }else if(product.definition.id == trophies_Pack_01)
        {
            ScoreManager.GetInstance().IncreaseTotalScore(300);
            ScoreManager.GetInstance().SaveCurrencyData();
            if (AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
            }
        }
        else if (product.definition.id == trophies_Pack_02)
        {
            ScoreManager.GetInstance().IncreaseTotalScore(1000);
            ScoreManager.GetInstance().SaveCurrencyData();
            if (AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
            }
        }

        else if (product.definition.id == trophies_Pack_03)
        {
            ScoreManager.GetInstance().IncreaseTotalScore(5000);
            ScoreManager.GetInstance().SaveCurrencyData();
            if (AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
            }
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        purchaseFailedPanel.SetActive(true);
    }

}
