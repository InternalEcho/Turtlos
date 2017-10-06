using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour {

    public GameObject player;
    public GameObject bullet;
    public Transform bulletEmitter;
    public float hp = 5.0f;
    public float fireRate;
    private float fireRateTime;
    public float bulletSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform.position);
        shoot();
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void shoot()
    {
        if(Time.time > fireRateTime)
        {
            fireRateTime = Time.time + fireRate;
            
            GameObject go = (GameObject)Instantiate(bullet, bulletEmitter.position, bulletEmitter.rotation);
            go.GetComponent<Rigidbody>().AddForce(bulletEmitter.forward * bulletSpeed);

        }
    }
}
