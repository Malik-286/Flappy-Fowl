using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Store : MonoBehaviour
{
     [SerializeField] GameObject purchaseFailedPanel;

    
    const string removeAds_ProductID = "com.aspireplay.flappyfowl.removeads";
 

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
        }
        
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        purchaseFailedPanel.SetActive(true);
    }

}
