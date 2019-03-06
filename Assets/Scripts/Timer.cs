using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int Seconds;
    private Text timer;
    private float timeRemaining;

    private void Awake()
    {
        timer = GetComponent<Text>();
        timeRemaining = Seconds;
    }

    private void Update()
    {
        if (timeRemaining > 0f)
        {
            //  Update countdown clock
            timeRemaining -= Time.deltaTime;
            Seconds = Mathf.FloorToInt(timeRemaining);

            //  Show current clock
            if (timeRemaining > 0f)
            {
                timer.text = Seconds.ToString("00");
            }
            else
            {
                //  The countdown clock has finished
                timer.text = "00";
            }
        }
    }
}