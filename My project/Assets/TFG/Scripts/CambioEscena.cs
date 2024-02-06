using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    private string Relajación;
    public GameObject iniciar;
   

    public void CargarSiguienteEscena()
    {
        SceneManager.LoadScene(Relajación);
    }

    public void IniciarJuego()
    {
        Debug.Log("pulsado");
        Jugador.jugando = true;
        iniciar.SetActive(false);
        Debug.Log("Ejecutado");
    }
}
