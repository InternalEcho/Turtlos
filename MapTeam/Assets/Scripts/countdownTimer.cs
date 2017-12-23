using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdownTimer : MonoBehaviour {

    [Header("Round Details")]
    public String timerText = "";
    public float timeLeft = 0.0f;
    public bool activated = false;
    public bool over = false;

    private int timeLeftToInt = 0;
        
    public void StopTimer()
    {
        timerText = "";
    //    Debug.Log("DISABLE timer!");
        activated = false;
    }

    public void StartTimer()
    {
        timeLeft = GameManagementScript.Instance.roundTime;
     //   Debug.Log("ENABLE timer!");
        activated = true;
        over = false;
    }
        
    void FixedUpdate()
    {
        if (!activated)
        {
       //     timerText = GameManagementScript.Instance.roundTime.ToString();
            return;
        }

        if (timeLeft > 0.0f)
        {
            timeLeft -= Time.deltaTime;
            timeLeftToInt = (int)Convert.ToInt32(timeLeft);
            timerText = timeLeftToInt.ToString();
        }
        if (timeLeft <= 0f)
        {
            StopTimer();
            over = true;
        }

    }
}
