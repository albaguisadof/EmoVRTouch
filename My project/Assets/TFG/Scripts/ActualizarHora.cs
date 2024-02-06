using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActualizarHora : MonoBehaviour
{
    TextMeshProUGUI textTiempo;
    private float tiempoJugado = 62;

    void Start()
    {
        textTiempo = GetComponent<TextMeshProUGUI>();

    }


    void Update()
    { 
        tiempoJugado -= Time.deltaTime;
        string tiempo = string.Format("{0:00}:{1:00}",
            Mathf.Floor(tiempoJugado / 60),
            tiempoJugado % 60);

        if( Jugador.jugando)
        {
            textTiempo.text = tiempo;
        }
     
    }

}
