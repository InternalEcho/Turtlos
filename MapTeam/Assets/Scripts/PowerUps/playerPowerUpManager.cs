using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPowerUpManager : MonoBehaviour
{
    [Header("Power-up parameters")]
    public float powerUpDuration = 10.0f;
    public bool activeShield;
    public float boostSpeed;

    enum powerUpType { becomeXS, becomeXL, speedBoost, shield };

    void Start()
    {
        activeShield = false;
        boostSpeed = this.GetComponent<player>().defaultPlayerSpeed * 2;    //boostSpeed is twice the default speed
    }

    public void becomeXS()
    {
        this.transform.localScale = new Vector3(.5f, .5f, .5f);
        StartCoroutine(PowerUpUptime(powerUpType.becomeXS));
    }

    public void becomeXL()
    {
        this.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        StartCoroutine(PowerUpUptime(powerUpType.becomeXL));
    }

    public void increaseSpeed()
    {
        this.GetComponent<player>().playerSpeed = boostSpeed;
        StartCoroutine(PowerUpUptime(powerUpType.speedBoost));
    }

    public void stunProjectile()    // can store many projectiles? will need a visual indicator
    {
        this.GetComponent<player>().numberStunProjectile = 3;
    }

    public void gainShield()
    {
        activeShield = true;
    }

    IEnumerator PowerUpUptime(powerUpType type)
    {
        yield return new WaitForSeconds(powerUpDuration);

        switch (type)
        {
            case powerUpType.becomeXL:
                Debug.Log("Size back to normal");   //debug
                this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
            case powerUpType.becomeXS:
                Debug.Log("Size back to normal");   //debug
                this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
            case powerUpType.speedBoost:
                Debug.Log("Speed down to normal");  //debug
                this.GetComponent<player>().playerSpeed = this.GetComponent<player>().defaultPlayerSpeed;
                break;
            default:
                Debug.Log("PowerUp Error");
                break;
        }
    }
}
