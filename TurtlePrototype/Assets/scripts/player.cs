﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float playerSpeed;
    public float bulletSpeed;
    public float fireRate;
    public float hp = 5.0f;
    private float fireRateCheck;
    public GameObject bullet;
    public Transform bulletEmitter;
    public Rigidbody rb;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
        move();
        turnToMouse();
        shoot();
        

        
    }
    void turnToMouse()
    {
        Plane ground = new Plane(Vector3.up, transform.position);
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayLength;
        if (ground.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(pointToLook);
        }
        Debug.DrawLine(cameraRay.origin, cameraRay.GetPoint(rayLength), Color.black);
    }

    void shoot()
    {
        if (Input.GetKey("space"))
        {
            if (Time.time > fireRateCheck)
            {
                GameObject go = (GameObject)Instantiate(bullet, bulletEmitter.position, bulletEmitter.rotation);
                go.GetComponent<Rigidbody>().AddForce(bulletEmitter.forward * bulletSpeed);
      
                fireRateCheck = Time.time + fireRate;
            }


        }
    }

    void move()
    {
        //transform.Translate(Input.GetAxisRaw("Horizontal") * playerSpeed, 0, Input.GetAxisRaw("Vertical") * playerSpeed, Space.World);
        if(Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            rb.AddForce(Input.GetAxisRaw("Horizontal") * playerSpeed * 3/4, 0, Input.GetAxisRaw("Vertical") * playerSpeed * 3/4);
        }
        else
        {
            rb.AddForce(Input.GetAxisRaw("Horizontal") * playerSpeed, 0, Input.GetAxisRaw("Vertical") * playerSpeed);
        }

    }
}
