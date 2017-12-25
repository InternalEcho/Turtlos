using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorites : GenericYvant {

    [Header("direction min max")]
    [SerializeField][Range(-1,0)]
    float x_min;
    [SerializeField][Range(-1,0)]
    float y_min;
    [SerializeField][Range(0, 1)]
    float x_max;
    [SerializeField][Range(0, 1)]
    float y_max;
    [Header("vitesse meteorite")]
    [SerializeField]
    float speed;

    private Vector3 impactPosition;
    private Vector3 offset = new Vector3(0, 1, 0);

    [SerializeField]
    AudioSource yee;

    private GameObject myShedew;
    private bool flag = true;
    public GameObject prefab;

    public override void activate()
    {
        base.activate();
        Debug.Log("meteorite!!!");
    }
    
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, impactPosition, step);

        if (this.transform.position.y < 0)// && flag)
        {
            flag = false;
            Destroy(myShedew);
            this.gameObject.GetComponent<Renderer>().enabled = false;
            yee.Play();
            Destroy(this.gameObject, 2);
        }
	}

    public override void spawn(float meteoriteHeight, int centerX, int centerY, int mapLengthX, int mapLengthY)
    {
        this.transform.position = new Vector3(centerX, meteoriteHeight, centerY);
        impactPosition = new Vector3(Random.Range(0, mapLengthX), 0, Random.Range(0, mapLengthY));

        myShedew = Instantiate(prefab, impactPosition + offset, Quaternion.identity) as GameObject;
        /*
        Vector3 direction = new Vector3(Random.Range(x_min, x_max), -1, Random.Range(y_min, y_max)); // vecteur direction + celle du ray
        //Vector3 direction = new Vector3(0, -1, 0);    //debug
        GetComponent<Rigidbody>().velocity = direction.normalized * speed;

        RaycastHit hit;//contient tt l'information sur le hit du ray

        if (Physics.Raycast(this.transform.position + direction * 2, direction, out hit, 50.0f)) // if hit
        {
            Vector3 offset = hit.point;
            offset.y = 1.0f; //shedew
            // Debug.Log(hit.collider.gameObject.name);
            myShedew = Instantiate(prefab, offset, Quaternion.identity) as GameObject;
        }
        */
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("PLAYER HIT");
            collision.gameObject.GetComponent<player>().loseHp();
            flag = false;
            Destroy(myShedew);
            yee.Play();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Terrain")
        {
            collision.gameObject.GetComponent<gridCellBehavior>().meteorHit();
            flag = false;
            Destroy(myShedew);
            yee.Play();
            Destroy(this.gameObject);
        }
    }
}
