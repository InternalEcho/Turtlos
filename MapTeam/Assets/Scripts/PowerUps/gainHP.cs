using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gainHP : genericPowerUp
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<playerPowerUpManager>().getPowerUpStatus())
            {
                collision.gameObject.GetComponent<playerPowerUpManager>().gainHP();
                Destroy(this.gameObject);
            }
        }
    }
}
