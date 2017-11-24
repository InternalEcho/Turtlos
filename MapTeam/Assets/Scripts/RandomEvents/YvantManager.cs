using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YvantManager : MonoBehaviour {

    public GameObject[] genericyvants;
    Vector3 randpos;
    public float min, max;
    public float minSec, maxSec;

    public void DebugEvent()
    {
        StartCoroutine(SpawnMultiple());
    }

    private IEnumerator SpawnMultiple()
    {
        
        for (int nb = 0; nb < genericyvants.Length; ++nb ) { 
            randpos = new Vector3(Random.Range(min, max), 20, Random.Range(min, max));
            yield return new WaitForSeconds(Random.Range(minSec,maxSec));
            GameObject newEvent = Instantiate(genericyvants[nb], randpos, Quaternion.identity) as GameObject;
        }
        //newEvent.GetComponent<GenericYvant>().activate();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
