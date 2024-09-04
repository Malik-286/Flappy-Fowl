using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using hardartcore.CasualGUI;

public class SkinsPanel : MonoBehaviour
{

    [SerializeField] Button[] skinsButtons;
    [SerializeField] int[] skinsPrices;
    [SerializeField] GameObject[] purchaseButtons;
    [SerializeField] AudioClip purchaseSoundEffect;

    [SerializeField] GameObject[] selectedTags;
    [SerializeField] GameObject[] selectedText;
    [SerializeField] const int defaultUnLockSkinNo = 0;

    [SerializeField] GameObject inAppPurchasePanel;

  

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
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
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
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
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
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
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
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
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
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
                print("Not Enough Points");
             }
        }
    }

    public void PurchaseSkin6()
    {


        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[5])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[5]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[6].interactable = true;
                purchaseButtons[5].SetActive(false);
                PlayerPrefs.SetInt("Skin6Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[5])
            {
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
                print("Not Enough Points");
            }
        }
    }
    public void PurchaseSkin7()
    {


        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[6])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[6]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[7].interactable = true;
                purchaseButtons[6].SetActive(false);
                PlayerPrefs.SetInt("Skin7Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[6])
            {
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
                print("Not Enough Points");
            }
        }
    }
    public void PurchaseSkin8()
    {


        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[7])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[7]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[8].interactable = true;
                purchaseButtons[7].SetActive(false);
                PlayerPrefs.SetInt("Skin8Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[7])
            {
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
                print("Not Enough Points");
            }
        }
    }
    public void PurchaseSkin9()
    {


        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[8])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[8]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[9].interactable = true;
                purchaseButtons[8].SetActive(false);
                PlayerPrefs.SetInt("Skin9Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[8])
            {
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
                print("Not Enough Points");
            }
        }
    }
    public void PurchaseSkin10()
    {


        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[9])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[9]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[10].interactable = true;
                purchaseButtons[9].SetActive(false);
                PlayerPrefs.SetInt("Skin10Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[9])
            {
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
                print("Not Enough Points");
            }
        }
    }
    public void PurchaseSkin11()
    {


        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[10])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[10]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[11].interactable = true;
                purchaseButtons[10].SetActive(false);
                PlayerPrefs.SetInt("Skin11Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[10])
            {
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
                print("Not Enough Points");
            }
        }
    }

    public void PurchaseSkin12()
    {


        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[11])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[11]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[12].interactable = true;
                purchaseButtons[11].SetActive(false);
                PlayerPrefs.SetInt("Skin12Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[11])
            {
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
                print("Not Enough Points");
            }
        }
    }

    public void PurchaseSkin13()
    {


        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[12])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[12]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[13].interactable = true;
                purchaseButtons[12].SetActive(false);
                PlayerPrefs.SetInt("Skin13Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[12])
            {
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
                print("Not Enough Points");
            }
        }
    }


    public void PurchaseSkin14()
    {


        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[13])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[13]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[14].interactable = true;
                purchaseButtons[13].SetActive(false);
                PlayerPrefs.SetInt("Skin14Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[13])
            {
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
                print("Not Enough Points");
            }
        }
    }


    public void PurchaseSkin15()
    {


        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[14])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[14]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[15].interactable = true;
                purchaseButtons[14].SetActive(false);
                PlayerPrefs.SetInt("Skin15Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[14])
            {
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
                print("Not Enough Points");
            }
        }
    }

    public void PurchaseSkin16()
    {


        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[15])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[15]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[16].interactable = true;
                purchaseButtons[15].SetActive(false);
                PlayerPrefs.SetInt("Skin16Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[15])
            {
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
                print("Not Enough Points");
            }
        }
    }

    public void PurchaseSkin17()
    {


        if (ScoreManager.GetInstance() != null)
        {
            if (ScoreManager.GetInstance().GetTotalScore() >= skinsPrices[16])
            {
                ScoreManager.GetInstance().DecreaseTotalScore(skinsPrices[16]);
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(purchaseSoundEffect, 1.0f);
                }
                if (ScoreManager.GetInstance() != null)
                {
                    ScoreManager.GetInstance().SaveCurrencyData();
                }


                skinsButtons[17].interactable = true;
                purchaseButtons[16].SetActive(false);
                PlayerPrefs.SetInt("Skin17Purchased", 1);
            }
            else if (ScoreManager.GetInstance().GetTotalScore() < skinsPrices[16])
            {
                inAppPurchasePanel.GetComponent<Dialog>().ShowDialog();
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
        if (PlayerPrefs.GetInt("Skin6Purchased", 0) == 1)
        {
            skinsButtons[6].interactable = true;
            purchaseButtons[5].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Skin7Purchased", 0) == 1)
        {
            skinsButtons[7].interactable = true;
            purchaseButtons[6].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Skin8Purchased", 0) == 1)
        {
            skinsButtons[8].interactable = true;
            purchaseButtons[7].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Skin9Purchased", 0) == 1)
        {
            skinsButtons[9].interactable = true;
            purchaseButtons[8].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Skin10Purchased", 0) == 1)
        {
            skinsButtons[10].interactable = true;
            purchaseButtons[9].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Skin11Purchased", 0) == 1)
        {
            skinsButtons[11].interactable = true;
            purchaseButtons[10].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Skin12Purchased", 0) == 1)
        {
            skinsButtons[12].interactable = true;
            purchaseButtons[11].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Skin13Purchased", 0) == 1)
        {
            skinsButtons[13].interactable = true;
            purchaseButtons[12].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Skin14Purchased", 0) == 1)
        {
            skinsButtons[14].interactable = true;
            purchaseButtons[13].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Skin15Purchased", 0) == 1)
        {
            skinsButtons[15].interactable = true;
            purchaseButtons[14].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Skin16Purchased", 0) == 1)
        {
            skinsButtons[16].interactable = true;
            purchaseButtons[15].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Skin17Purchased", 0) == 1)
        {
            skinsButtons[17].interactable = true;
            purchaseButtons[16].SetActive(false);
        }     
    }

}