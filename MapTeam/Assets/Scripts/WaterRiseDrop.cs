using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRiseDrop : MonoBehaviour {

    public float dropSpeed = 1.0f;
    public float riseSpeed = 1.0f;
    public float maxWaterLevel = 40.0f;
    public float minWaterLevel = 0.0f;
    private bool direction; //rise == true, drop == false
    private bool waterLevelMode; //true == "tides", false == "water level goes to the limit"

    //Change the invisible Water box to 2 boxes (top and bottom) so that the player can have a box collider

    public static void IgnoreLayerCollision(int layer1, int layer8, bool ignore = true)
    {
    }

    void Start()
    {
        direction = (Random.Range(0.0f, 1.0f) < 0.5); //randomizes the direction of the water level movement
        Debug.Log(direction);
        waterLevelMode = (Random.Range(0.0f, 1.0f) < 0.5);
    }

    void Update()
    {
        if (direction)
            waterRise();
        if (!direction)
            waterDrop();
    }

    void waterRise()
    {
        if (this.transform.position.y < maxWaterLevel)
        {
            Debug.Log(this.transform.position.y);
            Debug.Log(maxWaterLevel);
            float translation = Time.deltaTime * dropSpeed;
            transform.Translate(0, translation, 0);
        }
    }

    void waterDrop()
    {
        if (this.transform.position.y > minWaterLevel)
        {
            float translation = Time.deltaTime * dropSpeed;
            transform.Translate(0, -translation, 0);
        }
    }
}
