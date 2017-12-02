using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : GenericYvant
{
    private int floatDirection;
    public float spawnOffset, translationSpeed, cloudLifeDuration; //, cloudHeight;

    public override void activate()
    {
        base.activate();
        Debug.Log("Cloud9!!!");
    }

    public override void spawn(float height, int centerX, int centerY, int mapLengthX, int mapLengthZ)
    {
        Vector3 spawnPos = new Vector3(0.0f, 0.0f, 0.0f);
        floatDirection = Random.Range(0, 4);
        switch (floatDirection)
        {
            case 0: // -x
                spawnPos = new Vector3((float) -spawnOffset, height, Random.Range(0, mapLengthZ));
                break;
            case 1: // +x
                spawnPos = new Vector3((float) mapLengthX + spawnOffset, height, Random.Range(0, mapLengthZ));
                break;
            case 2: // -z
                spawnPos = new Vector3(Random.Range(0, mapLengthX), height, -spawnOffset);
                break;
            case 3: // +z
                spawnPos = new Vector3(Random.Range(0, mapLengthX), height, (float) mapLengthZ + spawnOffset);
                break;
            default:
                Debug.LogError("Cloud Spawn Error");
                break;
        }
        this.transform.position = spawnPos;
        this.transform.LookAt(new Vector3(Random.Range(0, mapLengthX), height, Random.Range(0, mapLengthZ)));
        Invoke("DestroyCloud", cloudLifeDuration);
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveCloud();
    }

    private void DestroyCloud()
    {
        Destroy(this.gameObject);
    }

    private void moveCloud()
    {
        float translation = Time.deltaTime * translationSpeed;
        this.transform.Translate(transform.forward * translation, Space.World);
    }
}