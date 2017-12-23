using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

// returns a String message
public class DisplayAnyMessage : MonoBehaviour {

    [Header("Message")]
    public String message = "";
    
	void Start ()
    {
        message = "";
	}
	
	public IEnumerator ReadySetGo()
    {
        message = "Ready";
        yield return new WaitForSeconds(1f);
        message = "Set";
        yield return new WaitForSeconds(1f);
        message = "Go!";
        yield return new WaitForSeconds(1f);
        message = "";
    }
}
