using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    int scoreNum = 0;
    public Text score;
    private void Update()
    {
        if (slider.value == 4)
        {
            slider.value = 0;
            scoreNum += 1;
            score.text = scoreNum.ToString();
            PlayerPrefs.SetInt("score", scoreNum);
        }
    }

    public void addIngrediant()
    {
        slider.value += 1;
    }


}
