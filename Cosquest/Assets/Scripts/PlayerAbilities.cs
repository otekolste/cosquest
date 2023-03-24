using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PlayerAbilities : MonoBehaviour {

    public ParticleSystem abilityParticle;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Powerup_Laser")) {
            // Enable the particle system
            abilityParticle.playOnAwake = true;
            abilityParticle.Play();
            StartCoroutine(StopParticleAfterDelay(5f));
            // Do something else when the ability is collected
            // ...
        }
    }

    IEnumerator StopParticleAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        abilityParticle.Stop();
    }
}
