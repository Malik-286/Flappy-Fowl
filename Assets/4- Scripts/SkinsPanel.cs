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


    void Start()
    {
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

   
  
}