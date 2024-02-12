using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPelotaNivel2 : MonoBehaviour
{
    public GameObject pelotaPrefab;
    public GameObject puntoExtraPrefab;
    public float tiempoEntrePelotas = 2;
    public Transform posicionDestino;
    private int vidas = 3;

    void Start()
    {
        Jugador.Instance.SetVidas(vidas);
        Vector3 vDestino = new Vector3(1, 0, -2);
        posicionDestino.position = vDestino;
        StartCoroutine(GenerarPelotas());
        vidas = Jugador.Instance.ObtenerVidas();
    }
   
    IEnumerator GenerarPelotas()
    {
        yield return new WaitForSeconds(4f);
        vidas = Jugador.Instance.ObtenerVidas();

        while (Jugador.jugando) 
        {
            float posicionZ, posicionY, posicionX, velocidadAleatoria;

            posicionZ = Random.Range(0f, 2f);
            posicionY = Random.Range(1f, 2f);

            if (Jugador.tiempoJugado > 0 && Jugador.tiempoJugado <= 25)
            {
                velocidadAleatoria = Random.Range(7f, 9f);
                tiempoEntrePelotas = 2f;
            }
            else if (Jugador.tiempoJugado > 25 && Jugador.tiempoJugado <= 45)
            {
                velocidadAleatoria = Random.Range(8.5f, 11f);
                tiempoEntrePelotas = 1.5f;
            }
            else
            {
                velocidadAleatoria = Random.Range(8.5f, 11f);
                tiempoEntrePelotas = 1f;
            }

            // Crear una nueva instancia de la pelota prefab
            GameObject prefab;
            int numAleatorio = Random.Range(0, 10);
            if (vidas >= 3 && numAleatorio < 9) 
            {
                prefab = pelotaPrefab;
            }
            else if ( vidas == 2 && numAleatorio < 7)
            {
                prefab = pelotaPrefab;
            }
            else if( vidas == 1 && numAleatorio < 5)
            {
                prefab = pelotaPrefab;
            }
            else if( vidas < 1 && numAleatorio < 3)
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
            rb.velocity = Vector3.zero * velocidadAleatoria;

            // Calcular dirección hacia la posición destino
            Vector3 direccion = (posicionDestino.position - nuevaPelota.transform.position).normalized;

            // Aplicar fuerza en la dirección hacia la posición destino
            rb.AddForce(direccion , ForceMode.Impulse); 

            //Agregamos la nueva pelota
            Pelota pelota = new Pelota();
            pelota.velocidad = velocidadAleatoria;
            pelota.tiempo = Jugador.tiempoJugado;

            if (posicionZ >= 1f)
            {
                pelota.posición = "Derecha";
            }
            else
            {
                pelota.posición = "Izquierda";
            }

            if (prefab.CompareTag("Pelota"))
            {
                pelota.tipo = "Pelota";
            }
            else
            {
                pelota.tipo = "Punto Extra";
            }

            Jugador.Instance.csvWriter.pelotas.Add(pelota);

            // Esperar un tiempo antes de generar la siguiente pelota
            yield return new WaitForSeconds(tiempoEntrePelotas);

            Destroy(nuevaPelota);

            vidas = Jugador.Instance.ObtenerVidas();

        }

    }

}
