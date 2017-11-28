using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldCondition : MonoBehaviour {

    public GameObject player;
    public Renderer render;
    public Collider collide;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        shieldAppear();
		
	}

    public void shieldAppear()
    {
        if (player.GetComponent<player>().activeShield == true)
        {
            render.enabled = true;
            collide.enabled = true;
        }
        else if(player.GetComponent<player>().activeShield == false)
            {
            render.enabled = false;
            collide.enabled = false;
        }
    }
}
