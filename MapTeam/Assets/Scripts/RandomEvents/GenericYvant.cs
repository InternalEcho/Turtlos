using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericYvant : MonoBehaviour {

    public virtual void activate() 
    {
        Debug.Log("GenericEvent!");
    }

    public virtual void spawn(float height, GameObject map)
    {
        Debug.Log("GenericSpawn!");
    }

}
