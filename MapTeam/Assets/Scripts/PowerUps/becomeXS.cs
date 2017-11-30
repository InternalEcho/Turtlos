using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class becomeXS : MonoBehaviour {

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
			collision.gameObject.GetComponent<player>().becomeXS();
            Destroy(this.gameObject);
        }
    }
}
