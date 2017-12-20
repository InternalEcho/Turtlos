using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToGameButton : MonoBehaviour
{
    public void GoToGame()
    {
        GameManagementScript.Instance.GoToGame();
    }
}
