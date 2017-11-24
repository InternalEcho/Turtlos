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
	private int numberStunProjectile;
  
    public GameObject bullet;
    public Transform bulletEmitter;
    private Rigidbody rb;

	private float deltaX;
	private float deltaY;

    public string playerNumber = "1";

    // Use this for initialization
    void Start () {
		numberStunProjectile = 0;
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
		rotate ();
        shoot();
        boost();
        

        
    }

	void rotate()
	{

		deltaX = Input.GetAxis("RotateX"+playerNumber);
        deltaY = Input.GetAxis("RotateY"+playerNumber); 

		Vector3 point = new Vector3 (deltaX, 0, deltaY);
	
		Vector3 pointToLook = transform.position + point;
		Vector3 currentLook = transform.position + transform.forward;

		transform.LookAt(Vector3.Lerp(currentLook, pointToLook, .5f));

        //		Debug.Log ("X:" + deltaX);
        //		Debug.Log ("Y:" + deltaY);
    }



    void shoot()
    {
        if (numberStunProjectile != 0)
        {
            if (Input.GetButtonDown("Fire"+playerNumber))
            {
                GameObject go = (GameObject)Instantiate(bullet, bulletEmitter.position, bulletEmitter.rotation);
                go.GetComponent<Rigidbody>().AddForce(bulletEmitter.forward * bulletSpeed);
                numberStunProjectile -= 1;
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
        if (Input.GetAxisRaw("Horizontal" + playerNumber) != 0 && Input.GetAxisRaw("Vertical" + playerNumber) != 0)
        {
            rb.AddForce(Input.GetAxisRaw("Horizontal" + playerNumber) * playerSpeed * 3 / 4, 0, Input.GetAxisRaw("Vertical" + playerNumber) * playerSpeed * 3 / 4);
        }
        else
        {
            rb.AddForce(Input.GetAxisRaw("Horizontal" + playerNumber) * playerSpeed, 0, Input.GetAxisRaw("Vertical" + playerNumber) * playerSpeed);
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

    public void becomeXS()
    {
        this.transform.localScale = new Vector3(.5f,.5f,.5f);
        StartCoroutine(PowerUpUptime(1));
    }

	public void becomeXL()
	{
		this.transform.localScale = new Vector3(2.0f,2.0f,2.0f);
		StartCoroutine(PowerUpUptime(2));
	}

    public void increaseSpeed()
    {
        playerSpeed *= 2;
        StartCoroutine(PowerUpUptime(3));
    }

    public void stunProjectile()    // can store many projectiles? will need a visual indicator
    {
        numberStunProjectile += 3;
    }
	public void gainShield()
	{
		//GameObject shield = (GameObject)Instantiate(bullet, bulletEmitter.position, bulletEmitter.rotation);
	}
    IEnumerator PowerUpUptime(int powerUpType)  //1 = becomeXS; 2 = increaseSpeed;
    {
        yield return new WaitForSeconds(powerUpDuration);

        switch (powerUpType)
        {
            case 1:
                Debug.Log("Size back to normal");   //debug
                this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
			case 2:
				Debug.Log("Size back to normal");   //debug
				this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				break;
            case 3:
                Debug.Log("Speed down to normal");  //debug
                playerSpeed /= 2;
                break;
            default:
                Debug.Log("PowerUp Error");
                break;
        }
    }
}

   