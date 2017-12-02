using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridCellBehavior : MonoBehaviour
{

    private float timeCollision;
    Color gridColor;
    bool changed = false;
    // Use this for initialization
    void Start()
    {
        gridColor = this.GetComponent<Renderer>().material.color;
    }
    public void flash()
    {
        this.GetComponent<Renderer>().material.color = Color.red;
    }

    public void meteor()
    {
        this.GetComponent<Renderer>().material.color = Color.black;
        timeCollision = Time.time;
        changed = true;

    }

    void Update()
    {
        if (Time.time > timeCollision + 2 && changed)
        {
            Debug.Log("after 2 sec");
            this.GetComponent<Renderer>().material.color = Color.yellow;
            changed = false;
        }
    }
}