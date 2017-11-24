using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : GenericYvant
{
    private int floatDirection;
    Vector3 spawnPos;
    public float mapBound, spawnDistance, translationSpeed, cloudLifeDuration;

    public override void activate()
    {
        base.activate();
        Debug.Log("Cloud9!!!");
    }

    public override void spawn()
    {
        floatDirection = Random.Range(0, 4);
        switch (floatDirection)
        {
            case 0: // -x
                spawnPos = new Vector3(-spawnDistance, 0, Random.Range(-spawnDistance, spawnDistance));
                break;
            case 1: // +x
                spawnPos = new Vector3(spawnDistance, 0, Random.Range(-spawnDistance, spawnDistance));
                break;
            case 2: // -z
                spawnPos = new Vector3(Random.Range(-spawnDistance, spawnDistance), 0, -spawnDistance);
                break;
            case 3: // +z
                spawnPos = new Vector3(Random.Range(-spawnDistance, spawnDistance), 0, spawnDistance);
                break;
            default:
                Debug.LogError("Cloud Spawn Error");
                break;
        }
        this.transform.position = spawnPos;
        this.transform.LookAt(new Vector3(Random.Range(-mapBound, mapBound), 0, Random.Range(-mapBound, mapBound)));
        Invoke("DestroyCloud", cloudLifeDuration);
    }

    // Use this for initialization
    void Start()
    {
        spawn();
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