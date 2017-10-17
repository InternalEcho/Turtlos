using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float expiryTime;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, expiryTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
            Debug.Log("enemy hit");
            collision.gameObject.GetComponent<enemyBehavior>().hp -= 1;
        }
        else if (collision.gameObject.name == "Player Holder")
        {
            Destroy(gameObject);
            Debug.Log("player hit");
            collision.gameObject.GetComponent<player>().hp -= 1;
        }
    }
}
