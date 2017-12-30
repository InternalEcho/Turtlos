using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {
    public Animator animator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool isMoving = this.transform.hasChanged;
        Debug.Log("ismoving: " + isMoving);
        animator.SetBool("IsMoving", true);
	}
}
