using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    private string Relajaci�n;
    public GameObject iniciar;
   

    public void CargarSiguienteEscena()
    {
        SceneManager.LoadScene(Relajaci�n);
    }

    public void IniciarJuego()
    {
        Debug.Log("pulsado");
        Jugador.jugando = true;
        iniciar.SetActive(false);
        Debug.Log("Ejecutado");
    }
}
