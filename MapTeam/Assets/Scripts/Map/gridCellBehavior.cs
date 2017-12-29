using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridCellBehavior : MonoBehaviour
{
    public float meteorHitColorChangeDuration;
    public Material gridColor;
    public GameObject smokeParticle;
    // Use this for initialization
    public void flash()
    {
        this.GetComponent<Renderer>().material.color = Color.red;
    }

    public void meteorHit()
    {
        this.GetComponent<Renderer>().material.color = Color.black;
        smokeParticle.SetActive(true);
        StartCoroutine(meteorHitColorChange());
    }

    IEnumerator meteorHitColorChange()
    {
        yield return new WaitForSeconds(meteorHitColorChangeDuration);
        smokeParticle.SetActive(false);
        this.GetComponent<Renderer>().material.color = gridColor.color;
    }
}