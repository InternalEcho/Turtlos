using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunParticle : MonoBehaviour {

    public ParticleSystem stunParticles;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public IEnumerator playStunParticles(float stunDuration)
    {
        this.gameObject.SetActive(true);
        yield return new WaitForSeconds(stunDuration);
        this.gameObject.SetActive(false);
    }
}
