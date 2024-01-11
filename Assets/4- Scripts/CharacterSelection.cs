using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{

    
    public void CharacterSelected()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SelectedCharacter(int index)
    {       
        PlayerPrefs.SetInt("SC", index);
        Debug.Log("You have selected number :"+index);
    }
 


}
