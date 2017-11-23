using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float playerSpeed;
    public float boostSpeed;
    public float bulletSpeed;
    //public float fireRate;
    public float hp;
    public float powerUpDuration;

    private float fireRateCheck;
    private float boostCooldown;
    private bool hasStunProjectile;
  
    public GameObject bullet;
    public Transform bulletEmitter;
    private Rigidbody rb;
    

	// Use this for initialization
	void Start () {
        hp = 5.0f;
        powerUpDuration = 3.0f;
        rb = gameObject.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No rigidbody on player.");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
        move();
        turnToMouse();
        shoot();
        boost();
        

        
    }
    void turnToMouse()
    {
        Plane ground = new Plane(Vector3.up, transform.position);
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayLength;
        if (ground.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(pointToLook);
        }
        Debug.DrawLine(cameraRay.origin, cameraRay.GetPoint(rayLength), Color.black);
    }

    void shoot()
    {
        if (hasStunProjectile)
        {
            if (Input.GetButton("Fire1"))
            {
                GameObject go = (GameObject)Instantiate(bullet, bulletEmitter.position, bulletEmitter.rotation);
                go.GetComponent<Rigidbody>().AddForce(bulletEmitter.forward * bulletSpeed);
                hasStunProjectile = false;
                /*if (Time.time > fireRateCheck)
                {
                    go.GetComponent<Rigidbody>().AddForce(bulletEmitter.forward * bulletSpeed);

                    fireRateCheck = Time.time + fireRate;
                }*/
            }
        }
    }

    void move()
    {
        //transform.Translate(Input.GetAxisRaw("Horizontal") * playerSpeed, 0, Input.GetAxisRaw("Vertical") * playerSpeed, Space.World);
        if(Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            rb.AddForce(Input.GetAxisRaw("Horizontal") * playerSpeed * 3/4, 0, Input.GetAxisRaw("Vertical") * playerSpeed * 3/4);
        }
        else
        {
            rb.AddForce(Input.GetAxisRaw("Horizontal") * playerSpeed, 0, Input.GetAxisRaw("Vertical") * playerSpeed);
        }

    }
    void boost()
    {
        if (Input.GetKey("space"))
        {
            if (Time.time > boostCooldown)
            {
                rb.AddForce(transform.forward * Time.deltaTime * boostSpeed);
                Debug.Log("boost activated");
                boostCooldown = Time.time + 5f;
            }
        }
    }

    public void becomeXL()
    {
        this.transform.localScale = new Vector3(2.0f,2.0f,2.0f);
        StartCoroutine(PowerUpUptime(1));
    }

    public void increaseSpeed()
    {
        playerSpeed *= 2;
        StartCoroutine(PowerUpUptime(2));
    }

    public void stunProjectile()    // can store many projectiles? will need a visual indicator
    {
        hasStunProjectile = true;
    }

    IEnumerator PowerUpUptime(int powerUpType)  //1 = becomeXL; 2 = increaseSpeed;
    {
        yield return new WaitForSeconds(powerUpDuration);

        switch (powerUpType)
        {
            case 1:
                Debug.Log("Size back to normal");   //debug
                this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
            case 2:
                Debug.Log("Speed down to normal");  //debug
                playerSpeed /= 2;
                break;
            default:
                Debug.Log("PowerUp Error");
                break;
        }
    }
}

   