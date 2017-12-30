using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerPowerUpManager : MonoBehaviour
{
    [Header("Power-up parameters")]
    public float powerUpDuration = 5.0f;
    public float boostSpeed;    //public for debug
    public bool activeShield;
    public Image healthBar;

    private bool activePowerUp;

    int numberOfPickups = 0;

    enum powerUpType { becomeXS, becomeXL, speedBoost, shield };

    void Start()
    {
        activeShield = false;
        activePowerUp = false;
        boostSpeed = this.GetComponent<player>().defaultPlayerSpeed * 2;    //boostSpeed is twice the default speed
    }

    public void becomeXS()
    {
        activePowerUp = true;
        Debug.Log("I AM SMALL" + numberOfPickups++);
        this.transform.localScale = new Vector3(.5f, .5f, .5f);
        StartCoroutine(PowerUpUptime(powerUpType.becomeXS));
    }

    public void becomeXL()
    {
        activePowerUp = true;
        Debug.Log("I AM FAT" + numberOfPickups++);
        this.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        StartCoroutine(PowerUpUptime(powerUpType.becomeXL));
    }

    public void increaseSpeed()
    {
        activePowerUp = true;
        Debug.Log("I AM FAST" + numberOfPickups++);
        this.GetComponent<player>().playerSpeed = boostSpeed;
        StartCoroutine(PowerUpUptime(powerUpType.speedBoost));
    }

    public void stunProjectile()    // can store many projectiles? will need a visual indicator
    {
        activePowerUp = true;
        Debug.Log("I AM ARMED" + numberOfPickups++);
        this.GetComponent<player>().numberStunProjectile = 3;
        this.GetComponent<player>().ammoBar.fillAmount = 1;
    }

    public void gainShield()
    {
        healthBar.GetComponent<Image>().color = Color.cyan;
        activePowerUp = true;
        Debug.Log("I AM SHIELDED" + numberOfPickups++);
        activeShield = true;
    }

    IEnumerator PowerUpUptime(powerUpType type)
    {
        Debug.Log("POWER UP UP" + numberOfPickups);

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

        activePowerUp = false;
    }

    public bool getPowerUpStatus()
    {
        return activePowerUp;
    }

    public void setPowerUpStatus(bool status)
    {
        activePowerUp = status;
    }

    //TESTING
    /*private void Update()
    {
        activePowerUp = false;
    }*/
}
