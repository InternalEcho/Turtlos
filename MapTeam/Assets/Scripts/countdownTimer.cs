using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdownTimer : MonoBehaviour {

    [Header("Round Details")]
    public String timerText = "";
    public float timeLeft;
    public bool activated = false;

    private int timeLeftToInt = 0;
        
    public void StopTimer()
    {
        timerText = "";
    //    Debug.Log("DISABLE timer!");
        activated = false;
    }

    public void StartTimer(float roundTime)
    {
        timeLeft = GameManagementScript.Instance.roundTime;
     //   Debug.Log("ENABLE timer!");
        activated = true;
        StartCoroutine(StartCountdown(roundTime));
    }
        
    void FixedUpdate()
    {
        if (!activated)
        {
            timerText = GameManagementScript.Instance.roundTime.ToString();
            return;
        }

        if (timeLeft > 0.0f)
        {
            Debug.Log("time left: " + timeLeft);
            timeLeftToInt = (int)Convert.ToInt32(timeLeft);
            timerText = timeLeftToInt.ToString();
        }
        if (timeLeft <= 0f)
        {
            StopTimer();
            GameManagementScript.Instance.timerOver = true;
        }

    }

    public IEnumerator StartCountdown(float roundTime)
    {
        timeLeft = roundTime;
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(100.0f);
            timeLeft--;
        }
    }
}
