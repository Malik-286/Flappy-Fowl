using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SkinsPanel : MonoBehaviour
{
    [SerializeField] Button[] skinsButtons;
    [SerializeField] GameObject[] selectedTags;
    [SerializeField] GameObject[] selectedText;
    [SerializeField] const int defaultUnLockSkinNo = 0;


    ScoreManager scoreManager;
    void Start()
    {

        EnableSelectedTag();
        EnableSelectedImage(PlayerPrefs.GetInt("SelectedSkin"));
        scoreManager = FindObjectOfType<ScoreManager>();
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

    void EnableUnLockedSkins()
    {
        // unlock all the skins 
        skinsButtons[0].interactable = true;
        skinsButtons[1].interactable = false;
        skinsButtons[2].interactable = false;
        skinsButtons[3].interactable = false;
        skinsButtons[4].interactable = false;
        skinsButtons[5].interactable = false;
    }

    void UnLockSkin(int price, int skinIndex)
    {
        if (scoreManager != null & scoreManager.GetTotalScore() >= price)
        {
            scoreManager.DecreaseCurrentScore(price);
            skinsButtons[skinIndex].interactable = true;
        }
    }

    void CheckStatusOfSkin()
    {

    }
}