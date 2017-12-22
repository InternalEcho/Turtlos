using System.Collections;
using UnityEngine;

public class YvantManager : MonoBehaviour {

    [Header("Global Randomizer Settings")] // all-events randomizer
    [Tooltip("Meteorites spawn frequency (%)")]  
    public float spawnFreqMeteorites; //change : maintenant 0.1%
    [Tooltip("Buff spawn frequency (%)")]   
    public float spawnFreqBuffs; 
    private int totalRoundFrames; // ~60 fps * roundTime
    private float divideFactor;
    //base 10

    [Header("Meteorite Randomizer Settings")]
    public GameObject[] meteorites;
    private int randEvent, mapCenterX, mapCenterY, mapLengthX, mapLengthY;
    public float minSec, maxSec, height;

    [Header("Buff Settings")]
    public GameObject[] buffs;
    private int randBuff;
    public float minSec_Buff, maxSec_Buff;
    private int randPosX, randPosY;
    public int buffHeight = 1;
    public GameObject map;
    

    private IEnumerator SpawnMeteorites()
    {
        {
            //  randEvent = Random.Range(0, genericyvants.Length);
            for (int i = 0; i < meteorites.Length; ++i)
            {
                GameObject newEvent = Instantiate(meteorites[i]) as GameObject;  // default spawn
                yield return new WaitForSeconds(Random.Range(minSec, maxSec));
                newEvent.GetComponent<GenericYvant>().spawn(height, mapCenterX, mapCenterY, mapLengthX, mapLengthY);
            }
        }
    }

    private IEnumerator SpawnBuffs()
    {
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
	void Start () 
    {
        totalRoundFrames = 60 * (int)GameManagementScript.Instance.roundTime; //~60 fps
        mapCenterX = map.GetComponent<GridMap>().getCenterX();
        mapCenterY = map.GetComponent<GridMap>().getCenterY();
        mapLengthX = map.GetComponent<GridMap>().lengthX;
        mapLengthY = map.GetComponent<GridMap>().lengthY;
        transform.position = new Vector3(mapCenterX, 0.0f, mapCenterY);
        divideFactor = 100f;
    }
	
	// Update is called once per frame
	void FixedUpdate () 
    {
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
	}

    /************** tests **************/

    public void DebugMeteorites()
    {
        StartCoroutine(SpawnMeteorites());
    }
}
