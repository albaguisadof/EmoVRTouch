﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneradorPelota : MonoBehaviour
{
    public GameObject pelotaPrefab;
    public float tiempoEntrePelotas = 1;
    private int vidas = 5;
    public Transform posicionDestino;

    void Start()
    {
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

            if(Jugador.tiempoJugado > 0 && Jugador.tiempoJugado <= 25)
            {
                posicionZ = Random.Range(-0.7f, 1.9f);
                posicionY = Random.Range(1f, 2f);
                velocidadAleatoria = Random.Range(7f, 9f);
                tiempoEntrePelotas = 2f;
            }
            else if(Jugador.tiempoJugado > 25 && Jugador.tiempoJugado <= 45 )
            {
                posicionZ = Random.Range(-0.7f, 1.9f);
                posicionY = Random.Range(1f, 2f);
                velocidadAleatoria = Random.Range(8.5f, 11f);
                tiempoEntrePelotas = 1.5f;
            }
            else 
            {
                posicionZ = Random.Range(-0.7f, 1.9f);
                posicionY = Random.Range(1f, 2f);
                velocidadAleatoria = Random.Range(8.5f, 11f);
                tiempoEntrePelotas = 1f;
            }
           

            // Crear una nueva instancia de la pelota prefab
            GameObject nuevaPelota = Instantiate(pelotaPrefab, new Vector3(-6f, posicionY, posicionZ), Quaternion.identity);

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
            pelota.posición = "";
            pelota.tiempo = Jugador.tiempoJugado;

            Jugador.Instance.csvWriter.pelotas.Add(pelota);

          
            // Esperar un tiempo antes de generar la siguiente pelota
            yield return new WaitForSeconds(tiempoEntrePelotas);
            Destroy(nuevaPelota);

            vidas = Jugador.Instance.ObtenerVidas();

        }
    }

}
