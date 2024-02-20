using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using OWOGame;

public class OWOScript 
{
    Sensation  colision, puntoExtra;
    BakedSensation  bakedPresion, bakedPuntoExtra;
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


    void CrearColision()
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

    void CrearPuntoExtra()
    {
        puntoExtra = SensationsFactory.Create(100, 3, 90, 0.3f, 0.3f, 0);

        puntoExtra.WithMuscles(Muscle.All);

        bakedPuntoExtra = puntoExtra.Bake(3, "PuntoExtra");
    }

    public void SendPuntoExtra()
    {
        if (isConnected)
        {
            OWO.Send(puntoExtra);
            Debug.Log("send perder");
        }
        else
        {
            Debug.LogWarning("Intento de enviar sensación sin conexión.");
        }
    }

    void CrearRelajacion()
    {
        puntoExtra = SensationsFactory.Create(100, 3, 90, 0.3f, 0.3f, 0);

        puntoExtra.WithMuscles(Muscle.All);

        bakedPuntoExtra = puntoExtra.Bake(3, "PuntoExtra");
    }

    public void SendRelajación()
    {
        if (isConnected)
        {
            OWO.Send(puntoExtra);
            Debug.Log("send perder");
        }
        else
        {
            Debug.LogWarning("Intento de enviar sensación sin conexión.");
        }
    }


    public void Start()
    {
        CrearColision();
        CrearPuntoExtra();
        CrearRelajacion();
        Connect();
    }



}
