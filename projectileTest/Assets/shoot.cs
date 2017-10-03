using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public GameObject bullet;
    public Transform bulletEmitter;
    public float bulletSpeed;
    public float fireRate;
    private float fireRateCheck;
	
	// Update is called once per frame
	void Update () {

        turnToMouse();
        if (Input.GetKeyDown("space"))
        {
            if(Time.time > fireRateCheck)
            {
                GameObject go = (GameObject)Instantiate(bullet, bulletEmitter.position, bulletEmitter.rotation);
                go.GetComponent<Rigidbody>().AddForce(bulletEmitter.forward * -bulletSpeed);
                Debug.Log(bulletEmitter.forward);
                fireRateCheck = Time.time + fireRate;
            }
            
           
        }
	}
    
    void turnToMouse()
    {
        /**
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //mousePosition.x -= Screen.width / 2;
        //mousePosition.y -= Screen.height / 2;
        Vector3 direction = new Vector3(-(mousePosition.x - transform.position.x),
           -transform.position.y
           -(mousePosition.z - transform.position.z));
        Vector3 direction2 = new Vector3(-500, 0, -500);
        transform.LookAt(direction);
        Debug.Log("x:" + mousePosition.x);
        Debug.Log("y:" + mousePosition.y);
        Debug.Log("z:" + mousePosition.z);
        Debug.Log("position:" + transform.position);
    **/

        Ray rayCamera = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(ground.Raycast(rayCamera, out rayLength))
        {
            Vector3 cursorPoint = rayCamera.GetPoint(rayLength);
            transform.LookAt(new Vector3(-cursorPoint.x, transform.position.y, -cursorPoint.z));
            Debug.DrawLine(rayCamera.origin, cursorPoint, Color.black);
        }
        
    }
    
}
