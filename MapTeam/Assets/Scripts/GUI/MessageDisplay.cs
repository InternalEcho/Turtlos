using System;
using UnityEngine.UI;
using UnityEngine;

public class MessageDisplay : MonoBehaviour {
    
    public Text messageBox;
    
    void Update ()
    {
        messageBox.text = GameManagementScript.Instance.anyTextBoxMessage;
        messageBox.enabled = GameManagementScript.Instance.enableAnyTextBox;
	}
}
