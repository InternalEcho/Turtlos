using System;
using UnityEngine.UI;
using UnityEngine;

public class TimerDisplay : MonoBehaviour {
    
    public Text timerBox;
    

    void Update ()
    {
        timerBox.text = GameManagementScript.Instance.timerBoxMessage;
        timerBox.enabled = GameManagementScript.Instance.enableTimerBox;
    }
}
