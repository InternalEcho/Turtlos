using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericPowerUp : MonoBehaviour {

	public IEnumerator lifeSpan(float powerUpLifeSpan)
    {
        yield return new WaitForSeconds(powerUpLifeSpan);
        //Make the powerUp flash when it's about to disappear?
        Destroy(this.gameObject);
    }
}
