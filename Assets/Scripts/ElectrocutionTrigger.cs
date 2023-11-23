using UnityEngine;

public class ElectrocutionTrigger : MonoBehaviour {
    public ParticleSystem electrocutionParticles;

    // La posición de destino en el eje X
    public float posicionDestinoX = 0.05f;

    // La velocidad de interpolación (ajusta según sea necesario)
    public float velocidadLerp = 2f;

    private float initialPosition;

    void Start() {
        initialPosition = transform.position.x;
        // Llama al método repetidamente con un intervalo de 10 segundos
        InvokeRepeating("ExecuteRepeatedly", 0f, 10f);
    }



    /*private void Update() {
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

    /*private void StartElectrocutionEffect() {
        electrocutionParticles.Play();
    }
    private void StopElectrocutionEffect() {
        electrocutionParticles.Stop();
    }*/


    // Método que se ejecutará repetidamente
    private void ExecuteRepeatedly() {
        // Tu lógica aquí
        Debug.Log("Ejecutando repetidamente");
        MoveObjectTowardsDestination();
    }

    private void MoveObjectTowardsDestination() {
        // Obtiene la posición actual del objeto en el eje X
        float posicionActualX = transform.position.x;

        // Calcula la nueva posición interpolada hacia la posición de destino
        float nuevaPosicionX = Mathf.Lerp(posicionActualX, posicionDestinoX, Time.deltaTime * velocidadLerp);

        // Actualiza la posición del objeto solo en el eje X
        transform.position = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);

        // Verifica si ha alcanzado la posición de destino
        if (Mathf.Abs(transform.position.x - posicionDestinoX) < 0.01f) {
            // Realiza las acciones necesarias cuando alcanza la posición de destino
            StartElectrocutionEffect();
        }
        else {
            // Detén el efecto de electrocución si no está en la posición de destino
            StopElectrocutionEffect();
        }
    }

    private void StartElectrocutionEffect() {
        // Lógica para iniciar el efecto de electrocución
        electrocutionParticles.Play();
    }

    private void StopElectrocutionEffect() {
        // Lógica para detener el efecto de electrocución
        electrocutionParticles.Stop();
    }
}
