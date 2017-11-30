using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YvantManager : MonoBehaviour {

    public GameObject[] genericyvants;
    private int randEvent;
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
            newEvent.GetComponent<GenericYvant>().spawn(height);
        }
    }

    private IEnumerator SpawnBuffs()
    {
        while(true)
        {
            randBuff = Random.Range(0, buffs.Length);
            randPosX = Random.Range((map.GetComponent<GridMap>().offsetX * -1)/2 + ((map.GetComponent<GridMap>().middleValueY + map.GetComponent<GridMap>().middleValueYpair) / 2)*-1, (map.GetComponent<GridMap>().offsetX * -1)/2 + ((map.GetComponent<GridMap>().middleValueY + map.GetComponent<GridMap>().middleValueYpair) / 2));
            randPosY = Random.Range((map.GetComponent<GridMap>().offsetY * -1)/2 + ((map.GetComponent<GridMap>().middleValueY + map.GetComponent<GridMap>().middleValueYpair) / 2)*-1, (map.GetComponent<GridMap>().offsetY * -1)/2 + ((map.GetComponent<GridMap>().middleValueY + map.GetComponent<GridMap>().middleValueYpair) / 2));
            Vector3 randPos = new Vector3(randPosX, buffHeight, randPosY);
            yield return new WaitForSeconds(Random.Range(minSec_Buff, maxSec_Buff));
            GameObject newBuff = Instantiate(buffs[randBuff], randPos, Quaternion.identity) as GameObject;
        }
    }
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnMultiple());
        StartCoroutine(SpawnBuffs());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
