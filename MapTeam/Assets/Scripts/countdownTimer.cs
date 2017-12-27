using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class countdownTimer : MonoBehaviour {

    [Header("Round Details")]
    public String timerText = "";
    public int timeLeft;
    public bool activated = false;
        
    public void StopTimer()
    {
        timerText = "";
        activated = false;
    }

    public void StartTimer()
    {
        timeLeft = GameManagementScript.Instance.roundTime;
        activated = true;
        StartCoroutine(StartCountdown());
    }
        
    void FixedUpdate()
    {
        if (!activated)
        {
            timerText = GameManagementScript.Instance.roundTime.ToString();
            return;
        }
        else
        {
            timerText = timeLeft.ToString();
        }
    }
    
    public IEnumerator StartCountdown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeLeft--;
        }
        StopTimer();
        GameManagementScript.Instance.timerOver = true;
    }
}
