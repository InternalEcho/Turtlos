using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregameSetup : MonoBehaviour {

    public void SetOneRound(bool set)
    {
        if (set)
        {
            Debug.Log("change to 1 round");
            GameManagementScript.Instance.roundsTotal = 1;
        }
    }

    public void SetThreeRounds(bool set)
    {
        if (set)
        {
            Debug.Log("change to 3 rounds");
            GameManagementScript.Instance.roundsTotal = 3;
        }
    }

    public void SetFiveRounds(bool set)
    {
        if (set)
        {
            Debug.Log("change to 5 rounds");
            GameManagementScript.Instance.roundsTotal = 5; 
        }
    }
}
