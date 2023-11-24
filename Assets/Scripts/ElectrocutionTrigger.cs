using UnityEngine;

public class ElectrocutionTrigger : MonoBehaviour {
    public ParticleSystem electrocutionParticles;
    public AudioSource electrocutionSound;

    // La posición de destino en el eje X
    public float posicionDestinoX = 0.05f;

    // La velocidad de interpolación (ajusta según sea necesario)
    public float velocidadLerp = 2f;

    private float initialPosition;
    private int contSounds = 0;

    void Start() {
        initialPosition = transform.position.x;
        contSounds = 0;
    }



    private void Update() {
        // Obtiene la posición actual del objeto en el eje X
        float posicionActualX = transform.position.x;

        // Calcula la nueva posición interpolada hacia la posición de destino
        float nuevaPosicionX = Mathf.Lerp(posicionActualX, posicionDestinoX, Time.deltaTime * velocidadLerp);

        // Actualiza la posición del objeto solo en el eje X
        transform.position = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);
    }

    private void FixedUpdate() {
        float modNewPos = Mathf.Abs(posicionDestinoX);
        float modPos = Mathf.Abs(transform.position.x);

        if (modPos < (modNewPos + 0.01) && modPos > (modNewPos - 0.01)) {
            //Debug.Log("Px " + modPos + " Nx " + modNewPos);
            //Debug.Log("collision");
            StartElectrocutionEffect();
            PlayElectrocutionSound();
        }
        else {
            StopElectrocutionEffect();
            //StopElectrocutionSound();
        }
    }

    /*private void OnCollisionEnter(Collision collision) {
        if (collision != null) {
            Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaa");
            if (collision.gameObject.CompareTag("Wall")) {
                Debug.Log("collision");
                StartElectrocutionEffect();
            }
            else {
                Debug.Log("-----");
            }
        }
    }*/

    private void StartElectrocutionEffect() {
        electrocutionParticles.Play();
    }
    private void StopElectrocutionEffect() {
        electrocutionParticles.Stop();
    }
    private void PlayElectrocutionSound() {
        contSounds++;
        if (electrocutionSound != null && contSounds > 3 && contSounds <= 4) {
            Debug.Log("Electrocution");
            electrocutionSound.Play();
        }
    }    
    private void StopElectrocutionSound() {
        if (electrocutionSound.isPlaying) {
            electrocutionSound.Stop();
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Electrocution");
    }
}
