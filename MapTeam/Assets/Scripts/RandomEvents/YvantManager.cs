using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YvantManager : MonoBehaviour {

    public GameObject[] genericyvants;
    private int randEvent;
    public float minSec, maxSec, height;

    public void DebugEvent()
    {
        //StartCoroutine(SpawnMultiple());
    }

    private IEnumerator SpawnMultiple()
    {
       while (true)    //boucle infinie
        {
            randEvent = Random.Range(0, genericyvants.Length);
            yield return new WaitForSeconds(Random.Range(minSec, maxSec));
            GameObject newEvent = Instantiate(genericyvants[randEvent]) as GameObject;  // default spawn
            newEvent.GetComponent<GenericYvant>().spawn(height);
        }
    }
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnMultiple());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
