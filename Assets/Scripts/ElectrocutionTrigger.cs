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
        // Llama al m�todo repetidamente con un intervalo de 10 segundos
        InvokeRepeating("ExecuteRepeatedly", 0f, 10f);
    }



    /*private void Update() {
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

    /*private void StartElectrocutionEffect() {
        electrocutionParticles.Play();
    }
    private void StopElectrocutionEffect() {
        electrocutionParticles.Stop();
    }*/


    // M�todo que se ejecutar� repetidamente
    private void ExecuteRepeatedly() {
        // Tu l�gica aqu�
        Debug.Log("Ejecutando repetidamente");
        MoveObjectTowardsDestination();
    }

    private void MoveObjectTowardsDestination() {
        // Obtiene la posici�n actual del objeto en el eje X
        float posicionActualX = transform.position.x;

        // Calcula la nueva posici�n interpolada hacia la posici�n de destino
        float nuevaPosicionX = Mathf.Lerp(posicionActualX, posicionDestinoX, Time.deltaTime * velocidadLerp);

        // Actualiza la posici�n del objeto solo en el eje X
        transform.position = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);

        // Verifica si ha alcanzado la posici�n de destino
        if (Mathf.Abs(transform.position.x - posicionDestinoX) < 0.01f) {
            // Realiza las acciones necesarias cuando alcanza la posici�n de destino
            StartElectrocutionEffect();
        }
        else {
            // Det�n el efecto de electrocuci�n si no est� en la posici�n de destino
            StopElectrocutionEffect();
        }
    }

    private void StartElectrocutionEffect() {
        // L�gica para iniciar el efecto de electrocuci�n
        electrocutionParticles.Play();
    }

    private void StopElectrocutionEffect() {
        // L�gica para detener el efecto de electrocuci�n
        electrocutionParticles.Stop();
    }
}
