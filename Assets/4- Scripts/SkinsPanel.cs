using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SkinsPanel : MonoBehaviour
{

    [SerializeField] Button[] skinsButtons;
    [SerializeField] int[] skinsPrices;
    [SerializeField] GameObject[] purchaseButtons;
    [SerializeField] AudioClip purchaseSoundEffect;

    [SerializeField] GameObject[] selectedTags;
    [SerializeField] GameObject[] selectedText;
    [SerializeField] const int defaultUnLockSkinNo = 0;

  

    void Start()
    {
        LoadPurchaseState();
        EnableSelectedImage(PlayerPrefs.GetInt("SelectedSkin"));     
    }



    public void SelectedSkin(int index)
    {
        PlayerPrefs.SetInt("SelectedSkin", index);
        PlayerPrefs.Save();
        EnableSelectedTag();
        EnableSelectedImage(index);
    }

    public void EnableSelectedTag()
    {

        foreach (GameObject tag in selectedTags)
        {
            tag.SetActive(false);
            selectedTags[PlayerPrefs.GetInt("SelectedSkin")].SetActive(true);
        }


    }

    public void EnableSelectedImage(int index)
    {

        for (int i = 0; i < selectedText.Length; i++)
        {
            selectedText[i].SetActive(i == index);
        }

    }


    public void PurchaseSkin1()
    {
         if (ScoreManager.GetInstance() != null)
        {
            if(ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[0])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[0]);
                if(AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if(ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }
                skinsButtons[1].interactable = true;
                purchaseButtons[0].SetActive(false);
                PlayerPrefs.SetInt("Skin1Purchased", 1);
            }else if(ScoreManager.GetInstance().GetTotalScore() < skinsPrices[0])
            {
                print("Not Enough Points");
             }
        }



        
    }

    public void PurchaseSkin2()
    {


        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[1])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[1]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }

                skinsButtons[2].interactable = true;
                purchaseButtons[1].SetActive(false);
                PlayerPrefs.SetInt("Skin2Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[1])
            {
                print("Not Enough Points");
             }
        }

    }

    public void PurchaseSkin3()
    {
            

        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[2])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[2]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[3].interactable = true;
                purchaseButtons[2].SetActive(false);
                PlayerPrefs.SetInt("Skin3Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[2])
            {
                print("Not Enough Points");
             }
        }
    }

    public void PurchaseSkin4()
    {
           

        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[3])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[3]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[4].interactable = true;
                purchaseButtons[3].SetActive(false);
                PlayerPrefs.SetInt("Skin4Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[3])
            {
                print("Not Enough Points");
             }
        }


    }

    public void PurchaseSkin5()
    {
          

        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[4])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[4]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[5].interactable = true;
                purchaseButtons[4].SetActive(false);
                PlayerPrefs.SetInt("Skin5Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[4])
            {
                print("Not Enough Points");
             }
        }
    }

    void LoadPurchaseState()
    {
        if (PlayerPrefs.GetInt("Skin1Purchased", 0) == 1)
        {
            skinsButtons[1].interactable = true;
            purchaseButtons[0].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Skin2Purchased", 0) == 1)
        {
            skinsButtons[2].interactable = true;
            purchaseButtons[1].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Skin3Purchased", 0) == 1)
        {
            skinsButtons[3].interactable = true;
            purchaseButtons[2].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Skin4Purchased", 0) == 1)
        {
            skinsButtons[4].interactable = true;
            purchaseButtons[3].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Skin5Purchased", 0) == 1)
        {
            skinsButtons[5].interactable = true;
            purchaseButtons[4].SetActive(false);
        }
    }

}