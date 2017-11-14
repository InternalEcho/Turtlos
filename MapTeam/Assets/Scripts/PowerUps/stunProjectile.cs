using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunProjectile : MonoBehaviour {

    public GameObject player;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player Holder")
        {
            player.GetComponent<player>().stunProjectile();
            Destroy(this.gameObject);
        }
    }
}
