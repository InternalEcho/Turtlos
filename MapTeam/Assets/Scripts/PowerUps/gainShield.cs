using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gainShield : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
			collision.gameObject.GetComponent<playerPowerUpManager>().gainShield();
            Destroy(this.gameObject);
        }
    }
}
