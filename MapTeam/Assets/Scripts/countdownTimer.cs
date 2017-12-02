using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdownTimer : MonoBehaviour {

    [Header("Temps de jeu")]
    public float StartingTime = 30.0f;
    private float timeLeft = 30.0f;
    public String timerText;
    public bool isTimerActive = false;

    // Stops and reset the timer
    public void ResetTimer() {
        timeLeft = StartingTime;
        StopTimer();
    } 

    // Starts the timer with the indicated time.
    public void StartTimer(float time) {
        StartingTime = time;
        timeLeft = StartingTime;
        isTimerActive = true;
    }

    public void StopTimer() {
        isTimerActive = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //if not active, skip everything
        if (!isTimerActive) return;

        timeLeft -= Time.deltaTime; 
        
        if (timeLeft > 0.0f) {
            int timeLeftInt = (int)Convert.ToInt32(timeLeft);
            timerText = timeLeftInt.ToString();
        }
        else {
            Debug.Log("Time's up");
            StopTimer();
        }
        
	}

}
