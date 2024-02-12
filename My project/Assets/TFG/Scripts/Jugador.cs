using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private static Jugador _instance;
    public static Jugador Instance => _instance;
    OWOScript owo = new OWOScript();
    public bool activarOWO = true;
    public CSVWriter csvWriter = new CSVWriter();

    public int vidas = 5;
    public static float tiempoJugado = 0f;

    public GameObject finalizar;
    public GameObject iniciar;

    public Light luzRoja;

    public static bool jugando = false;

    // Evento para notificar cambios en las vidas
    public delegate void VidasChangedDelegate(int nuevasVidas);
    public event VidasChangedDelegate VidasChangedEvent;

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
        luzRoja.intensity = 0f;

        if(activarOWO)
        {
            owo.Start();
        }
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
        if(vidas > 0)
        {
            vidas--;
            VidasChangedEvent?.Invoke(vidas);
            owo.SendColision();
        }
        else
        {
            vidas = 0;
            owo.SendColision();
        }
        
    }

    public void SetVidas(int vidas)
    {
        this.vidas = vidas;
    }

    public void GanarVida()
    {
        vidas++;
        VidasChangedEvent?.Invoke(vidas);
        owo.SendPuntoExtra();
    }

    public int ObtenerVidas()
    {
        return vidas;
    }
}
