using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class becomeXL : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<playerPowerUpManager>().getPowerUpStatus())
            {
                collision.gameObject.GetComponent<playerPowerUpManager>().becomeXL();
                Destroy(this.gameObject);
            }
        }
    }
}

