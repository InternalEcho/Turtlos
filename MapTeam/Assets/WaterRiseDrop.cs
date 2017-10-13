using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRiseDrop : MonoBehaviour {

    public float dropSpeed = 1.0f;
    public float riseSpeed = 1.0f;
    private bool bottomReached = false;
    private bool topReached = false;
    private bool direction; //rise == true, drop == false

    void Start()
    {
        int randomizer = Random.Range(0, 2);
        
        //randomize here
    }

    void Update()
    {
        waterDrop();
    }

    void waterRise()
    {
        if (topReached == false)
        {
            float translation = Time.deltaTime * dropSpeed;
            transform.Translate(0, translation, 0);
        }
    }

    void waterDrop()
    {
        if (bottomReached == false)
        {
            float translation = Time.deltaTime * dropSpeed;
            transform.Translate(0, -translation, 0);
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Seefloor")
        {
            Debug.Log("YeeWater");
            if (direction)
                topReached = true;
            if (!direction)
                bottomReached = true;
        }
    }
}
