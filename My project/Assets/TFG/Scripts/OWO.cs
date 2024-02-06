using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using OWOGame;

public class OWOScript 
{
    Sensation  colision, perder;
    BakedSensation  bakedPresion, bakedPerder;
    GameAuth auth;
    Muscle[] muscles;
    bool isConnected = false;

    void Connect()
    {
        try
        {
            OWO.AutoConnect();
            Debug.Log("Conectado");
            isConnected = true;
;
        }
        catch (Exception e)
        {
            Debug.LogError("Error al conectar: " + e.Message);
        }
    }

    public void Disconnect() { 
        if(isConnected)
        {
            OWO.Disconnect();
            Debug.Log("OWO Desconectado");
        }
    }


    void crearColision()
    {
        colision = SensationsFactory.Create(100, 3, 90, 0.3f, 0.3f, 0);

        colision.WithMuscles(Muscle.All);

        bakedPresion = colision.Bake(3, "Presion");
    }

    public void SendColision()
    {
        if (isConnected)
        {
            OWO.Send(colision);
            Debug.Log("send colisión");
        }
        else
        {
            Debug.LogWarning("Intento de enviar sensación sin conexión.");
        }
    }

    void crearPerder()
    {
        perder = SensationsFactory.Create(100, 3, 90, 0.3f, 0.3f, 0);

        perder.WithMuscles(Muscle.All);

        bakedPresion = perder.Bake(3, "Perder");
    }

    public void SendPerder()
    {
        if (isConnected)
        {
            OWO.Send(perder);
            Debug.Log("send perder");
        }
        else
        {
            Debug.LogWarning("Intento de enviar sensación sin conexión.");
        }
    }


    public void Start()
    {
        crearColision();
        crearPerder();
        Connect();
    }



}
