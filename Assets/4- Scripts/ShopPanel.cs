using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{

    [SerializeField] Button[] skinsButtons;
    [SerializeField] GameObject[] selectedTags;
    [SerializeField] GameObject removeAdsButton;


    void Start()
    {

         EnableSelectedTag();
        if(PlayerPrefs.GetString("AdsStatusKey") == "disabled")
        {
            removeAdsButton.SetActive(false);
        }
         
    }





    public void SelectedSkin(int index)
    {
        PlayerPrefs.SetInt("SelectedSkin", index);
        PlayerPrefs.Save();
        EnableSelectedTag();
    }

    public void EnableSelectedTag()
    {
        
        foreach (GameObject tag in selectedTags)
        {
            tag.SetActive(false);                      
            selectedTags[PlayerPrefs.GetInt("SelectedSkin")].SetActive(true);            
        }
      
    }
}
