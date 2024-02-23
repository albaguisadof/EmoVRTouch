using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionPelotaPruebas : MonoBehaviour
{
    private HashSet<GameObject> pelotasColisionadas = new HashSet<GameObject>();
    public AudioSource audioColision;
    public AudioSource audioPuntoExtra;

    public Light luzRoja;

    // Posición inicial del rayo
    Vector3 rayOrigin = new Vector3(1f, 0f, -1f);


    void Update()
    {
        // Obtener la posición de la cámara
        Vector3 camPosition = Camera.main.transform.position;
        Vector3 vector3 = camPosition - rayOrigin;

        // Lanzar un rayo hacia abajo desde la posición de la cámara
        RaycastHit hit;
        if (Physics.Raycast(camPosition, Vector3.down, out hit))
        {
            // Verificar si la colisión es con la pelota y si no se ha contado ya esta colisión
            if (hit.collider.CompareTag("Pelota") && !pelotasColisionadas.Contains(hit.collider.gameObject))
            {
                // Marcar la pelota como colisionada
                pelotasColisionadas.Add(hit.collider.gameObject);

                Jugador.Instance.PerderVida();

                Debug.Log("Colisión");

                audioColision.Play();

                StartCoroutine(ActivarLuzColision());

            }
            if (hit.collider.CompareTag("PuntoExtra") && !pelotasColisionadas.Contains(hit.collider.gameObject))
            {
                // Marcar la pelota como colisionada
                pelotasColisionadas.Add(hit.collider.gameObject);

                Jugador.Instance.GanarVida();

                Debug.Log("Vida extra");

                audioPuntoExtra.Play();
            }
        }
    }

    IEnumerator ActivarLuzColision()
    {
        luzRoja.intensity = 1000;
        yield return new WaitForSeconds(1f);
        luzRoja.intensity = 1;
    }
}
