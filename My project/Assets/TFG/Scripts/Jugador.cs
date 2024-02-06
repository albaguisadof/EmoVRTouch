using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private static Jugador _instance;
    public static Jugador Instance => _instance;
    OWOScript owo = new OWOScript();
    public CSVWriter csvWriter = new CSVWriter();

    public int vidas = 5;
    public static float tiempoJugado = 0f;
    public int numColisiones = 0;

    public GameObject finalizar;
    public GameObject iniciar;

    public Light luzRoja;

    public static bool jugando = false;

    // Evento para notificar cambios en las vidas
    public delegate void VidasChangedDelegate(int nuevasVidas);
    public event VidasChangedDelegate VidasChangedEvent;

    private int aciertos = 0;
    private int numPelotasLanzadas = 0;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        finalizar.SetActive(false);
        iniciar.SetActive(true);
        owo.Start();
        luzRoja.intensity = 0f;
    }

    void Start()
    {
        StartCoroutine(Iniciar());
    }

    void Update()
    {
        if(jugando) {
            tiempoJugado += Time.deltaTime;
            if (tiempoJugado >= 60f && tiempoJugado < 61f)
            {
                Finalizar();
            }
        }
        
    }

     void Finalizar()
    {
        jugando = false;
        finalizar.SetActive(true);
        owo.Disconnect();
        csvWriter.WriteCSV();
       // yield return new WaitForSeconds(1f);
       // Application.Quit();
    }

    IEnumerator Iniciar()
    {
        yield return new WaitForSeconds(2f);
        iniciar.SetActive(false);
        jugando = true;
    }

  
    public void PerderVida()
    {
        if (vidas > 0)
        {
            vidas--;
            numColisiones++;
            VidasChangedEvent?.Invoke(vidas);
            owo.SendColision();
        }
        else
        {
            numColisiones++;
            owo.SendColision();

        }
       

    }

    public int ObtenerVidas()
    {
        return vidas;
    }

    public void IncrementarNumColisiones()
    {
        numColisiones++;
    }
}
