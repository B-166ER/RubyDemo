using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerUILabel; //drag UI Text object here via Inspector

    private float t_offset = 0f; // set to nothing, can be set to an offset if needed.
    private int t_minutes;
    private int t_seconds;
    private int t_milliseconds;

    [Range(5,180)]
    [SerializeField]float realTime;
    float t;
    bool NotifiedBefore = false;

    void OnDestroy()
    {
        NotifiedBefore = false;
    }
    // generic countdown clock. triggers aaction when ended.
    private void Update()
    {
        t = realTime - Time.timeSinceLevelLoad - t_offset;

        t_minutes = ((int)t / 60); // t(seconds) / 60 = total minutes
        t_seconds = ((int)t % 60); // t(seconds) % 60 = remaining seconds 
        t_milliseconds = ((int)(t * 100)) % 100; // (total seconds * 1000) % 1000 = remaining milliseconds

        //display the text in a 00:00:00 format
        timerUILabel.text = string.Format("{0:00}:{1:00}:{2:00}", t_minutes, t_seconds, t_milliseconds);
        

        if (t < 0 && !NotifiedBefore) {
            GameManager.instance.TimerEnded();
            NotifiedBefore = true;
        }
    }
}
