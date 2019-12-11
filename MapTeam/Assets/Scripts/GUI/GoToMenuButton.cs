using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMenuButton : MonoBehaviour {

	public void GoToMenu()
    {
       GameManagementScript.Instance.GoToMenu();
    }
}
