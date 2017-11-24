using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YvantManager : MonoBehaviour {

    public GameObject[] genericyvants;
    private int randEvent;
    public float minSec, maxSec;

    public void DebugEvent()
    {
        StartCoroutine(SpawnMultiple());
    }

    private IEnumerator SpawnMultiple()
    {
        while (true)    //boucle infinie
        {
            randEvent = Random.Range(0, genericyvants.Length);
            yield return new WaitForSeconds(Random.Range(minSec, maxSec));
            GameObject newEvent = Instantiate(genericyvants[randEvent], new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
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
