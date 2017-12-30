using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseSpeed : genericPowerUp
{

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<playerPowerUpManager>().getPowerUpStatus())
            {
                collision.gameObject.GetComponent<playerPowerUpManager>().increaseSpeed();
                Destroy(this.gameObject);
            }
        }
    }
}
