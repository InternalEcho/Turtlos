﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class becomeXL : MonoBehaviour
{

    public GameObject player;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player Holder")
        {
            player.GetComponent<player>().becomeXL();
            Destroy(this.gameObject);
        }
    }
}

