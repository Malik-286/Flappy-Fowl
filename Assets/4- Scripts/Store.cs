using hardartcore.CasualGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Store : MonoBehaviour
{

     [SerializeField] GameObject purchaseFailedPanel;
     [SerializeField] AudioClip purchaseSoundEffect;



     const string removeAds_ProductID = "com.agsventures.fowlescape.removeads";
       const string trophies_Pack_300 = "com.agsventures.fowlescape.300trophies";
       const string trophies_Pack_1000 = "com.agsventures.fowlescape.1000trophies";
       const string trophies_Pack_5000 = "com.agsventures.fowlescape.5000trophies";
       const string trophies_Pack_10000 = "com.agsventures.fowlescape.10000trophies";




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

        }else if(product.definition.id == trophies_Pack_300)
        {
            ScoreManager.GetInstance().IncreaseTotalScore(300);
            ScoreManager.GetInstance().SaveCurrencyData();
            if (AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
            }
        }
        else if (product.definition.id == trophies_Pack_1000)
        {
            ScoreManager.GetInstance().IncreaseTotalScore(1000);
            ScoreManager.GetInstance().SaveCurrencyData();
            if (AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
            }
        }

        else if (product.definition.id == trophies_Pack_5000)
        {
            ScoreManager.GetInstance().IncreaseTotalScore(5000);
            ScoreManager.GetInstance().SaveCurrencyData();
            if (AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
            }
        }
        else if (product.definition.id == trophies_Pack_10000)
        {
            ScoreManager.GetInstance().IncreaseTotalScore(10000);
            ScoreManager.GetInstance().SaveCurrencyData();
            if (AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
            }
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        purchaseFailedPanel.GetComponent<Dialog>().ShowDialog();
    }

}
