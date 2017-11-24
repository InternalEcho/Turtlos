using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericYvant : MonoBehaviour {

    public virtual void activate() 
    {
        Debug.Log("GenericEvent!");
    }

    public virtual void spawn()
    {
        Debug.Log("GenericSpawn!");
    }

}
