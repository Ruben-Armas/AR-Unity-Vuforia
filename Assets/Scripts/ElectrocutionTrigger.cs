using UnityEngine;

public class ElectrocutionTrigger : MonoBehaviour {
    public ParticleSystem electrocutionParticles;

    // La posici�n de destino en el eje X
    public float posicionDestinoX = 0.05f;

    // La velocidad de interpolaci�n (ajusta seg�n sea necesario)
    public float velocidadLerp = 2f;

    private float initialPosition;

    void Start() {
        initialPosition = transform.position.x;
    }



    private void Update() {
        // Obtiene la posici�n actual del objeto en el eje X
        float posicionActualX = transform.position.x;

        // Calcula la nueva posici�n interpolada hacia la posici�n de destino
        float nuevaPosicionX = Mathf.Lerp(posicionActualX, posicionDestinoX, Time.deltaTime * velocidadLerp);

        // Actualiza la posici�n del objeto solo en el eje X
        transform.position = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);
    }

    private void FixedUpdate() {
        float modNewPos = Mathf.Abs(posicionDestinoX);
        float modPos = Mathf.Abs(transform.position.x);

        if (modPos < (modNewPos + 0.01) && modPos > (modNewPos - 0.01)) {
            //Debug.Log("Px " + modPos + " Nx " + modNewPos);
            //Debug.Log("collision");
            StartElectrocutionEffect();
        }
        else StopElectrocutionEffect();
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

}
