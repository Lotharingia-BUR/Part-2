using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 10;
    public Text timerValue;
    int minutes;
    int seconds;
    string sec;

    private void Start()
    {
        timerValue.text = "05:00";
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        minutes = (int) timer / 60;
        seconds = (int) timer - (60 * minutes);
        if (seconds < 10)
        {
            sec = "0" + seconds.ToString();
        } else
        {
            sec = seconds.ToString();
        }
        
        timerValue.text = "0" + minutes.ToString() + ":" + sec;

        if (timer < 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
