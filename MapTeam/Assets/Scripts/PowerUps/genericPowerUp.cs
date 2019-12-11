using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericPowerUp : MonoBehaviour {

    void Update()
    {
        transform.Rotate(Vector3.up, 150 * Time.deltaTime);
    }

    public IEnumerator lifeSpan(float powerUpLifeSpan)
    {
        float lifeSpanAlmostUp = powerUpLifeSpan / 10;  //Start flashing at 1/10 the lifespan of a PowerUp
        float lifeSpanFlashInterval = lifeSpanAlmostUp / 20;
        float lifeSpanNormal = lifeSpanAlmostUp * 9;
        /*Debug.Log("LifeSpanAlmostUp: " + lifeSpanAlmostUp);
        Debug.Log("LifeSpanFlashInterval: " + (float) lifeSpanFlashInterval);
        Debug.Log("LifeSpanNormal: " + lifeSpanNormal);*/
        yield return new WaitForSeconds(lifeSpanNormal);
        for (int i = 0; i < 10; i++)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(lifeSpanFlashInterval);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(lifeSpanFlashInterval);
        }
        //Make the powerUp flash when it's about to disappear?
        Destroy(this.gameObject);
    }
}
