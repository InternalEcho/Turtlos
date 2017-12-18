using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour {

    [Header("Round Settings")][Range(0.0f, 300.0f)]
    public float roundTime = 30.0f;
    public String timerText = "";
    public bool activated = false;
    private float timeLeft = 0.0f;

    private int timeLeftToInt = 0;

    void Start()
    {  }

    public void StopTimer()
    {
        timerText = "";
        activated = false;
    }

    public void StartTimer()
    {
        timeLeft = roundTime;
        activated = true;
    }
    
    void FixedUpdate()
    {
        if (!activated) return;

        if (timeLeft > 0.0f)
        {
            timeLeft -= Time.deltaTime;
            int timeLeftInt = (int)Convert.ToInt32(timeLeft);
            timerText = timeLeftInt.ToString();
        }
        else
        {
            Debug.Log("Time's up");
            StopTimer();
        }
    }
}
