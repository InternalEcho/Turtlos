using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseSpeed : MonoBehaviour {

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
			collision.gameObject.GetComponent<playerPowerUpManager>().increaseSpeed();
            Destroy(this.gameObject);
        }
    }
}
