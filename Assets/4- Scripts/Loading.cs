using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] Slider loadingSlider;
    [SerializeField] TextMeshProUGUI loadingText;

    float currentValue;
    void Update()
    {
        currentValue += Time.deltaTime / 1.5f;
        loadingSlider.value = Mathf.Clamp01(currentValue);
        loadingText.text = ("Loading...")+ (int)(loadingSlider.value * 100)+ "%";

        if(loadingSlider.value >= 1)
        {
            SceneManager.LoadScene("Main Menu");
        }

    }
}
