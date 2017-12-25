using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float expiryTime;
    public float stunDuration;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, expiryTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<player>().playerSpeed = 0;
            StartCoroutine(stunRecovery(collision.gameObject));
            Destroy(this.gameObject, 0.1f);
        }
    }

    private IEnumerator stunRecovery(GameObject victim)
    {
        yield return new WaitForSeconds(stunDuration);
        victim.GetComponent<player>().playerSpeed = victim.GetComponent<player>().defaultPlayerSpeed;
    }
}
