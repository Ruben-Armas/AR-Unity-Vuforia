using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrocutionTrigger : MonoBehaviour {
    public ParticleSystem electrocutionParticles;

    void Start() {

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision != null) {
            if (collision.gameObject.CompareTag("Wall")) {
                Debug.Log("collision");
                StartElectrocutionEffect();
            }
        }
    }

    private void StartElectrocutionEffect() {
        electrocutionParticles.Play();
    }
}
