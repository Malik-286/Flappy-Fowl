using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PremiumSkins : MonoBehaviour
{

    public static PremiumSkins Instance;

    [SerializeField] GameObject[] ShopPremiumSkinsButtons;
    [SerializeField] Button[] ShopPremiumSkins;
    [SerializeField] TextMeshProUGUI[] SelectText;
    [SerializeField] AudioClip purchaseSoundEffect;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (PlayerPrefs.GetInt("PremiumSkinPurchased1") == 1)
        {
            ShopPremiumSkinsButtons[0].SetActive(false);
            ShopPremiumSkins[0].interactable = true;
        }
        if (PlayerPrefs.GetInt("PremiumSkinPurchased2") == 1)
        {
            ShopPremiumSkinsButtons[1].SetActive(false);
            ShopPremiumSkins[1].interactable = true;
        }
        if (PlayerPrefs.GetInt("PremiumSkinPurchased3") == 1)
        {
            ShopPremiumSkinsButtons[2].SetActive(false);
            ShopPremiumSkins[2].interactable = true;
        }
        if (PlayerPrefs.GetInt("PremiumSkinPurchased4") == 1)
        {
            ShopPremiumSkinsButtons[3].SetActive(false);
            ShopPremiumSkins[3].interactable = true;
        }
        if (PlayerPrefs.GetInt("PremiumSkinPurchased5") == 1)
        {
            ShopPremiumSkinsButtons[4].SetActive(false);
            ShopPremiumSkins[4].interactable = true;
        }
        if (PlayerPrefs.GetInt("PremiumSkinPurchased6") == 1)
        {
            ShopPremiumSkinsButtons[5].SetActive(false);
            ShopPremiumSkins[5].interactable = true;
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }
    public void UnlockPremiumSkins(int SkinNumber)
    {
        print("Skin Number in Shop" + SkinNumber);
        ShopPremiumSkinsButtons[SkinNumber].SetActive(false);
        ShopPremiumSkins[SkinNumber].interactable = true;
        if (SkinNumber == 0)
        {
            PlayerPrefs.SetInt("PremiumSkinPurchased1", 1);
        }
        if (SkinNumber == 1)
        {
            PlayerPrefs.SetInt("PremiumSkinPurchased2", 1);
        }
        if (SkinNumber == 2)
        {
            PlayerPrefs.SetInt("PremiumSkinPurchased3", 1);
        }
        if (SkinNumber == 3)
        {
            PlayerPrefs.SetInt("PremiumSkinPurchased4", 1);
        }
        if (SkinNumber == 4)
        {
            PlayerPrefs.SetInt("PremiumSkinPurchased5", 1);
        }
        if (SkinNumber == 5)
        {
            PlayerPrefs.SetInt("PremiumSkinPurchased6", 1);
        }
        PlayerPrefs.Save();
    }

    public void SelectSkin(int SkinNumber)
    {
        for (int i = 0; i < SelectText.Length; i++)
        {
            SelectText[i].text = "Select".ToString();
        }
        SelectText[SkinNumber].text = "Selected".ToString();

        PlayerPrefs.SetInt("SelectedSkin", SkinNumber);
        PlayerPrefs.Save();
    }
    // Update is called once per frame
    void Update()
    { 

    }
}
