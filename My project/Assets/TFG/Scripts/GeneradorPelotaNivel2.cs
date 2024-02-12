using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPelotaPrueba2 : MonoBehaviour
{
    public GameObject pelotaPrefab;
    public GameObject puntoExtraPrefab;
    public GameObject finalizar;
    public float tiempoEntrePelotas = 2;
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
        yield return new WaitForSeconds(4f);

        while (contador < 4) 
        {
            // Generar posici�n aleatoria en el eje z
            float posicionZ = Random.Range(-0.5f, 1.5f);

            // Generar posici�n aleatoria en el eje y
            float posicionY = Random.Range(1f, 2f);


            // Crear una nueva instancia de la pelota prefab
            GameObject prefab;
            if (contador % 2 == 0) 
            {
                prefab = pelotaPrefab;
            }
            else
            {
                prefab = puntoExtraPrefab;
            }
           

            GameObject nuevaPelota = Instantiate(prefab, new Vector3(-6f, posicionY, posicionZ), Quaternion.identity); ;

            // Ajustamos la velocidad
            Rigidbody rb = nuevaPelota.GetComponent<Rigidbody>();
            float velocidadAleatoria = Random.Range(7f, 9f);
            rb.velocity = Vector3.zero * velocidadAleatoria;

            // Calcular dirección hacia la posición destino
            Vector3 direccion = (posicionDestino.position - nuevaPelota.transform.position).normalized;

            // Aplicar fuerza en la dirección hacia la posición destino
            rb.AddForce(direccion , ForceMode.Impulse); // Ajusta la fuerza según sea necesario

            contador++;

            // Esperar un tiempo antes de generar la siguiente pelota
            yield return new WaitForSeconds(tiempoEntrePelotas);

            Destroy(nuevaPelota);

        }

        finalizar.SetActive(true);
    }

}
