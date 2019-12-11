using System.Collections;
using UnityEngine;

public class YvantManager : MonoBehaviour {

    [Header("Global Randomizer Settings")] // all-events randomizer
    public float minSec;
    public float maxSec;
    [Tooltip("Meteorites spawn frequency (%)")]  
    public float spawnFreqMeteorites; 
    [Tooltip("Meteorites spawn frequency (%)")]
    public float spawnFreqClouds;
    [Tooltip("Buff spawn frequency (%)")]   
    public float spawnFreqBuffs; 
    /*private int totalRoundFrames; // ~60 fps * roundTime
    private float divideFactor;*/
    //base 10

    [Header("Meteorite Settings")]
    public GameObject meteorite;
    private int mapLengthX, mapLengthY;
    public float meteoriteHeight;

    [Header("Cloud Settings")]
    public GameObject cloud;
    public float cloudHeight;

    [Header("Buff Settings")]
    public GameObject[] buffs;
    public float buffLifeSpan;
    private int randBuff, randPosX, randPosY;
    //public float minSec_Buff, maxSec_Buff;
    public int buffHeight = 1;
    public GameObject map;

    private void SpawnMeteorites()
    {
        GameObject newEvent = Instantiate(meteorite) as GameObject;  // default spawn
        newEvent.GetComponent<GenericYvant>().spawn(meteoriteHeight, mapLengthX, mapLengthY);
    }

    private void SpawnClouds()
    {
        GameObject newEvent = Instantiate(cloud) as GameObject;  // default spawn
        newEvent.GetComponent<GenericYvant>().spawn(cloudHeight, mapLengthX, mapLengthY);
    }

    private void SpawnBuffs()
    {
        randBuff = Random.Range(0, buffs.Length);
        randPosX = Random.Range(0, mapLengthX);
        randPosY = Random.Range(0, mapLengthY);
        Vector3 randPos = new Vector3(randPosX, buffHeight, randPosY);
        GameObject newBuff = Instantiate(buffs[randBuff], randPos, Quaternion.identity) as GameObject;
        StartCoroutine(newBuff.GetComponent<genericPowerUp>().lifeSpan(buffLifeSpan));
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
        mapLengthX = map.GetComponent<GridMap>().lengthX;
        mapLengthY = map.GetComponent<GridMap>().lengthY;
        transform.position = new Vector3(map.GetComponent<GridMap>().getCenterX(), 0.0f, map.GetComponent<GridMap>().getCenterY());
        //divideFactor = 100f;
    }
	
	void FixedUpdate () 
    {
        /* LE BRANDON WAY OF THINGS
        totalRoundFrames = (1 / Time.deltaTime) * (int)GameManagementScript.Instance.roundTime; 
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
*/

        //SAFE MODE FOR TESTING
        //float randMeteorites = Random.Range(1.0f, 1.0f);

        float randMeteorites = Random.Range(0.0f, 1.0f);
        float randClouds = Random.Range(0.0f, 1.0f);
        float randBuffs = Random.Range(0.0f, 1.0f);

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
