using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YvantManager : MonoBehaviour {

    public GameObject[] genericyvants;
    private int randEvent, mapCenterX, mapCenterY, mapLengthX, mapLengthY;
    public float minSec, maxSec, height;

    public GameObject[] buffs;
    private int randBuff;
    public float minSec_Buff, maxSec_Buff;
    private int randPosX, randPosY;
    public GameObject map;
    public int buffHeight = 1;

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
            newEvent.GetComponent<GenericYvant>().spawn(height, mapCenterX, mapCenterY, mapLengthX, mapLengthY);
        }
    }

    private IEnumerator SpawnBuffs()
    {
        while(true)
        {
            randBuff = Random.Range(0, buffs.Length);
            randPosX = Random.Range(0, mapLengthX);
            randPosY = Random.Range(0, mapLengthY);
            Vector3 randPos = new Vector3(randPosX, buffHeight, randPosY);
            yield return new WaitForSeconds(Random.Range(minSec_Buff, maxSec_Buff));
            GameObject newBuff = Instantiate(buffs[randBuff], randPos, Quaternion.identity) as GameObject;
        }
    }
	// Use this for initialization
	void Start () {
        mapCenterX = map.GetComponent<GridMap>().getCenterX();
        mapCenterY = map.GetComponent<GridMap>().getCenterY();
        mapLengthX = map.GetComponent<GridMap>().lengthX;
        mapLengthY = map.GetComponent<GridMap>().lengthY;
        transform.position = new Vector3(mapCenterX, 0.0f, mapCenterY);
        StartCoroutine(SpawnMultiple());
        StartCoroutine(SpawnBuffs());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
