using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdownTimer : MonoBehaviour {

    [Header("Round Details")][Range(0.0f, 300.0f)]
    public float roundTime = 30.0f;
    public String timerText = "";
    public bool activated = false;
    private float timeLeft = 0.0f;

    private int timeLeftToInt = 0;

    void Start()
    {    }
    
    public void StopTimer()
    {
        timerText = "";
        activated = false;
    }

    public void StartTimer()
    {
       // yield return StartCoroutine(ReadySetGo());
        timeLeft = roundTime;
        activated = true;
        //yield return 0;
    }

    IEnumerator ReadySetGo()
    {
        timerText = "Ready";
        yield return new WaitForSeconds(1.0f);
        timerText = "Set";
        yield return new WaitForSeconds(1f);
        timerText = "Go!";
        yield return new WaitForSeconds(0.5f);
    }
    
    void FixedUpdate()
    {
        if (!activated) return;

        if (timeLeft > 0.0f)
        {
            timeLeft -= Time.deltaTime;
            timeLeftToInt = (int)Convert.ToInt32(timeLeft);
            timerText = timeLeftToInt.ToString();
        }
        else
        {
            Debug.Log("Time's up");
            StopTimer();
        }
    }
}
