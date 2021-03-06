﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunProjectile : genericPowerUp
{

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<playerPowerUpManager>().getPowerUpStatus())
            {
                collision.gameObject.GetComponent<playerPowerUpManager>().stunProjectile();
                Destroy(this.gameObject);
            }
        }
    }
}
