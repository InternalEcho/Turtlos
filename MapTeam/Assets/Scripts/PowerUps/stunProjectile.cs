using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunProjectile : MonoBehaviour {

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
			collision.gameObject.GetComponent<player>().stunProjectile();
            Destroy(this.gameObject);
        }
    }
}
