using System.Collections;
using UnityEngine;

public class YvantManager : MonoBehaviour {

    [Header("Global Randomizer Settings")] // all-events randomizer
    public float minSec, maxSec;
    [Tooltip("Meteorites spawn frequency (%)")]  
    public float spawnFreqMeteorites; //change : maintenant 0.1%
    [Tooltip("Meteorites spawn frequency (%)")]
    public float spawnFreqClouds;
    [Tooltip("Buff spawn frequency (%)")]   
    public float spawnFreqBuffs; 
    private int totalRoundFrames; // ~60 fps * roundTime
    private float divideFactor;
    //base 10

    [Header("Meteorite Settings")]
    public GameObject meteorite;
    public int mapCenterX, mapCenterY, mapLengthX, mapLengthY;  //WAS PRIVATE
    public float meteoriteHeight;

    [Header("Cloud Settings")]
    public GameObject cloud;
    public float cloudHeight;

    [Header("Buff Settings")]
    public GameObject[] buffs;
    private int randBuff;
    public float minSec_Buff, maxSec_Buff;
    private int randPosX, randPosY;
    public int buffHeight = 1;
    public GameObject map;

    private void SpawnMeteorites()
    {
        GameObject newEvent = Instantiate(meteorite) as GameObject;  // default spawn
        newEvent.GetComponent<GenericYvant>().spawn(meteoriteHeight, mapCenterX, mapCenterY, mapLengthX, mapLengthY);
    }

    private void SpawnClouds()
    {
        GameObject newEvent = Instantiate(cloud) as GameObject;  // default spawn
        newEvent.GetComponent<GenericYvant>().spawn(cloudHeight, mapCenterX, mapCenterY, mapLengthX, mapLengthY);
    }

    private void SpawnBuffs()
    {
        randBuff = Random.Range(0, buffs.Length);
        randPosX = Random.Range(0, mapLengthX);
        randPosY = Random.Range(0, mapLengthY);
        Vector3 randPos = new Vector3(randPosX, buffHeight, randPosY);
        GameObject newBuff = Instantiate(buffs[randBuff], randPos, Quaternion.identity) as GameObject;
    }

    /*private IEnumerator SpawnMeteorites()
    {
        GameObject newEvent = Instantiate(meteorite) as GameObject;  // default spawn
        newEvent.GetComponent<GenericYvant>().spawn(meteoriteHeight, mapCenterX, mapCenterY, mapLengthX, mapLengthY);
        yield return new WaitForSeconds(Random.Range(minSec, maxSec));
    }

    private IEnumerator SpawnClouds()
    {
        GameObject newEvent = Instantiate(cloud) as GameObject;  // default spawn
        newEvent.GetComponent<GenericYvant>().spawn(cloudHeight, mapCenterX, mapCenterY, mapLengthX, mapLengthY);
        yield return new WaitForSeconds(Random.Range(minSec, maxSec));
    }

    private IEnumerator SpawnBuffs()
    {
        randBuff = Random.Range(0, buffs.Length);
        randPosX = Random.Range(0, mapLengthX);
        randPosY = Random.Range(0, mapLengthY);
        Vector3 randPos = new Vector3(randPosX, buffHeight, randPosY);
        yield return new WaitForSeconds(Random.Range(minSec_Buff, maxSec_Buff));
        GameObject newBuff = Instantiate(buffs[randBuff], randPos, Quaternion.identity) as GameObject;
    }*/

    void Start () 
    {
        totalRoundFrames = 60 * (int)GameManagementScript.Instance.roundTime; //~60 fps
        /*mapCenterX = map.GetComponent<GridMap>().getCenterX();
        mapCenterY = map.GetComponent<GridMap>().getCenterY();
        mapLengthX = map.GetComponent<GridMap>().lengthX;
        mapLengthY = map.GetComponent<GridMap>().lengthY;*/
        mapCenterX = 25;
        mapCenterY = 25;
        mapLengthX = 50;
        mapLengthY = 50;
        transform.position = new Vector3(mapCenterX, 0.0f, mapCenterY);
        divideFactor = 100f;
    }
	
	void FixedUpdate () 
    {
        /* LE BRANDON WAY OF THINGS
        float randMeteorites = Random.Range(0f, (float)totalRoundFrames);
        float randBuffs = Random.Range(0f, (float)totalRoundFrames);

        // Debug.Log(randMeteorites + " < " + (spawnFreqMeteorites * totalRoundFrames / 100f) + " = " + (randMeteorites <= spawnFreqMeteorites * totalRoundFrames / 100f));
        // Debug.Log(randBuffs + " < " + (spawnFreqBuffs * totalRoundFrames / 100f) + " = " + (randBuffs <= spawnFreqBuffs * totalRoundFrames / 100f));
        
        if (GameManagementScript.Instance.timer.activated == true)
        { 
            if (randMeteorites <= spawnFreqMeteorites * totalRoundFrames / divideFactor) 
            {
                StartCoroutine(SpawnMeteorites());
            }
            if (randBuffs <= spawnFreqBuffs * totalRoundFrames / divideFactor)                 
            {
                StartCoroutine(SpawnBuffs());
            }
        }

        if (GameManagementScript.Instance.timer.activated == true)
        { 
            if (randMeteorites <= spawnFreqMeteorites) 
            {
                StartCoroutine(SpawnMeteorites());
            }
            if (randBuffs <= spawnFreqBuffs)                 
            {
                StartCoroutine(SpawnBuffs());
            }
        }*/
        float randMeteorites = Random.Range(0f, 1.0f);
        float randClouds = Random.Range(0f, 1.0f);
        float randBuffs = Random.Range(0f, 1.0f);

        if (GameManagementScript.Instance.timer.activated == true)
        {
            if (randMeteorites <= spawnFreqMeteorites)
            {
                SpawnMeteorites();
            }
            if (randClouds <= spawnFreqClouds)
            {
                SpawnClouds();
            }
            if (randBuffs <= spawnFreqBuffs)
            {
                SpawnBuffs();
            }
        }
    }

    /************** tests **************/

        public void DebugMeteorites()
    {
        //StartCoroutine(SpawnMeteorites());
    }
}
