using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class becomeXL : MonoBehaviour
{

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
			collision.gameObject.GetComponent<player>().becomeXL();
            Destroy(this.gameObject);
        }
    }
}

