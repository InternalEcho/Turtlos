using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float expiryTime;
    public float stunDuration;
    // Use this for initialization
    void Start () {
        //Destroy(gameObject, expiryTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<player>().playerSpeed = 0;
            collision.gameObject.GetComponent<player>().playerStunned(stunDuration);
            Destroy(this.gameObject);
        }
    }
}
