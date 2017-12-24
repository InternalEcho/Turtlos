using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridCellBehavior : MonoBehaviour
{

    private float timeCollision;
    public float meteorHitColorChangeDuration;
    public Material gridColor;
    // Use this for initialization
    public void flash()
    {
        this.GetComponent<Renderer>().material.color = Color.red;
    }

    public void meteorHit()
    {
        this.GetComponent<Renderer>().material.color = Color.black;
        StartCoroutine(meteorHitColorChange());
    }

    IEnumerator meteorHitColorChange()
    {

        yield return new WaitForSeconds(meteorHitColorChangeDuration);
        this.GetComponent<Renderer>().material.color = gridColor.color;
    }

    private void Start()
    {
        Debug.Log(gridColor.color);
    }
}