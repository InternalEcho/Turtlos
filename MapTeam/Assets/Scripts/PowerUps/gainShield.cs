using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gainShield : MonoBehaviour
{

    public GameObject player;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player Holder")
        {
            //player.GetComponent<player>().gainShield();
            Destroy(this.gameObject);
        }
    }
}
