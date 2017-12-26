using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostGameMenu : MonoBehaviour {

    public GameObject postGameMenu;

    public void displayPostGameMenu()
    {
        postGameMenu.SetActive(true);
    }
}
