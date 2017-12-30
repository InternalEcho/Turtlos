using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shedew : MonoBehaviour {

    [SerializeField][Range(0.0f,0.1f)]
    public float plus = 0.001f;

	// Use this for initialization
	void Start () {

        this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 current = this.transform.localScale;
        current.x += plus;
        current.z += plus;
        this.transform.localScale = current;
	}
}
