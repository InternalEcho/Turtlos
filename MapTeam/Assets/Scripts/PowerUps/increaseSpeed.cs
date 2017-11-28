using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseSpeed : MonoBehaviour {

    public GameObject player;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player Holder")
        {
            player.GetComponent<player>().increaseSpeed();
            Destroy(this.gameObject);
        }
    }
}
