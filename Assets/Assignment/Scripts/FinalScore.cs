using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text score;
    void Start()
    {
        score.text = "You made " + PlayerPrefs.GetInt("score").ToString() + " potions!!!";
    }
}
