using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPelotaPrueba : MonoBehaviour
{
    public GameObject pelotaPrefab;
    public GameObject finalizar;
    public float tiempoEntrePelotas = 1;
    public Transform posicionDestino;
    private int contador = 0;

  
    void Start()
    {
        Vector3 vDestino = new Vector3(1, 0, -2);
        posicionDestino.position = vDestino;
        StartCoroutine(GenerarPelotas());
    }
   
    IEnumerator GenerarPelotas()
    {
        yield return new WaitForSeconds(3f);

        while (contador < 2) 
        {
            // Generar posición aleatoria
            float posicionZ = Random.Range(0.25f, 2.25f);
            float posicionY = Random.Range(1f, 2f);
            float posicionX = -6f;

            // Crear una nueva instancia de la pelota prefab
            GameObject nuevaPelota = Instantiate(pelotaPrefab, new Vector3(posicionX, posicionY, posicionZ), Quaternion.identity);

            // Ajustamos la velocidad
            Rigidbody rb = nuevaPelota.GetComponent<Rigidbody>();
            float velocidadAleatoria = Random.Range(7f, 9f);
            rb.velocity = Vector3.zero * velocidadAleatoria;

            // Calcular dirección hacia la posición destino
            Vector3 direccion = (posicionDestino.position - nuevaPelota.transform.position).normalized;

            // Aplicar fuerza en la dirección hacia la posición destino
            rb.AddForce(direccion , ForceMode.Impulse); 


            // Esperar un tiempo antes de generar la siguiente pelota
            yield return new WaitForSeconds(tiempoEntrePelotas);

            Destroy(nuevaPelota);

            contador++;

        }

        finalizar.SetActive(true);
    }

}
