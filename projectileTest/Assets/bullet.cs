using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

   
    public float expiryTime = 2.0f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, expiryTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
