using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleRenderer : MonoBehaviour {

    public GameObject LeftBackFin, LeftFrontFin, RightBackFin, RightFrontFin, tail, lowerJaw, upperJaw;

    public void turnOnRenderers()
    {
        this.gameObject.GetComponent<Renderer>().enabled = true;    //turtle shell
        LeftBackFin.GetComponent<Renderer>().enabled = true;
        LeftFrontFin.GetComponent<Renderer>().enabled = true;
        RightBackFin.GetComponent<Renderer>().enabled = true;
        RightFrontFin.GetComponent<Renderer>().enabled = true;
        tail.GetComponent<Renderer>().enabled = true;
        lowerJaw.GetComponent<Renderer>().enabled = true;
        upperJaw.GetComponent<Renderer>().enabled = true;
    }

    public void turnOffRenderers()
    {
        this.gameObject.GetComponent<Renderer>().enabled = false;    //turtle shell
        LeftBackFin.GetComponent<Renderer>().enabled = false;
        LeftFrontFin.GetComponent<Renderer>().enabled = false;
        RightBackFin.GetComponent<Renderer>().enabled = false;
        RightFrontFin.GetComponent<Renderer>().enabled = false;
        tail.GetComponent<Renderer>().enabled = false;
        lowerJaw.GetComponent<Renderer>().enabled = false;
        upperJaw.GetComponent<Renderer>().enabled = false;
    }
}
