using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using OWOGame;

public class OWOScript :MonoBehaviour
{
    Sensation  colision, puntoExtra1, puntoExtra2, puntoExtra3, relajación1, relajación2, relajación3;
    BakedSensation  bakedColision, bakedPuntoExtra, bakedRelajacion;
    GameAuth auth;
    Muscle[] muscles;
    bool isConnected = false;

    Sensation relajacion = Sensation.Parse("11~Relajación~100,12,60,0,0,0,|9%100,8%100,3%100,2%100&100,10,60,0,0,0,|7%100,6%100,5%100,4%100&100,12,60,0,0,0,|0%100,1%100&100,10,60,0,0,0,|5%100,4%100,7%100,6%100~weapon-0~TFG");
    Sensation puntoExtra = Sensation.Parse("10~VidaExtra~20,1,90,0,0,0,|3%100,2%100,9%100,8%100&20,1,90,0,0,0,|5%100,4%100,7%100,6%100&20,2,90,0,0,0,|0%100,1%100~weapon-0~TFG");
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
        colision = SensationsFactory.Create(100, 0.2f, 90, 0, 0, 0);

        colision.WithMuscles(Muscle.All);

        bakedColision = colision.Bake(1, "Colisión");
    }

    public void SendColision()
    {
        if (isConnected)
        {
            OWO.Send(colision);
            Debug.Log("Send colisión");
        }
        else
        {
            Debug.LogWarning("Intento de enviar sensación sin conexión.");
        }
    }

    void CrearPuntoExtra()
    {
        puntoExtra1 = SensationsFactory.Create(20, 0.1f, 90, 0, 0, 0);
        puntoExtra2 = SensationsFactory.Create(20, 0.1f, 90, 0, 0, 0);
        puntoExtra3 = SensationsFactory.Create(20, 0.2f, 90, 0, 0, 0);

        puntoExtra1.WithMuscles(Muscle.Abdominal_L, Muscle.Abdominal_R, Muscle.Dorsal_L, Muscle.Dorsal_R);
        puntoExtra2.WithMuscles(Muscle.Dorsal_R, Muscle.Dorsal_R, Muscle.Arm_L, Muscle.Arm_R);
        puntoExtra3.WithMuscles(Muscle.Pectoral_L, Muscle.Pectoral_R);

    }

    public IEnumerator SendPuntoExtra()
    {
        if (isConnected)
        {
            OWO.Send(puntoExtra1, Muscle.Abdominal_L, Muscle.Abdominal_R, Muscle.Lumbar_R, Muscle.Lumbar_R);
            yield return new WaitForSeconds(0.1f);
            OWO.Send(puntoExtra2, Muscle.Dorsal_R, Muscle.Dorsal_L, Muscle.Arm_L, Muscle.Arm_R);
            yield return new WaitForSeconds(0.1f);
            OWO.Send(puntoExtra3, Muscle.Pectoral_L, Muscle.Pectoral_R);
        }
        else
        {
            Debug.LogWarning("Intento de enviar sensación sin conexión.");
        }
    }

    void CrearRelajacion()
    {
        relajación1 = SensationsFactory.Create(100, 1.2f, 60, 0, 0, 0);
        relajación2 = SensationsFactory.Create(100, 1f, 60, 0, 0, 0);
        relajación3 = SensationsFactory.Create(100, 1.2f, 60, 0, 0, 0);

        relajación1.WithMuscles(Muscle.Abdominal_L, Muscle.Abdominal_R, Muscle.Dorsal_L, Muscle.Dorsal_R);
        relajación2.WithMuscles(Muscle.Dorsal_R, Muscle.Dorsal_R, Muscle.Arm_L, Muscle.Arm_R);
        relajación3.WithMuscles(Muscle.Pectoral_L, Muscle.Pectoral_R);

        
    }


    public IEnumerator SendRelajación()
    {
        if (isConnected)
        {
            
            //OWO.Send(relajación1.Append(relajación2.Append(relajación3.Append(relajación2))));
           // OWO.Send(relajacion);
            OWO.Send(relajación1,Muscle.Abdominal_L, Muscle.Abdominal_R, Muscle.Lumbar_R, Muscle.Lumbar_L);
            yield return new WaitForSeconds(1.2f);
            OWO.Send(relajación2, Muscle.Dorsal_R, Muscle.Dorsal_L, Muscle.Arm_L, Muscle.Arm_R);
            yield return new WaitForSeconds(1);
            OWO.Send(relajación3, Muscle.Pectoral_L, Muscle.Pectoral_R);
            yield return new WaitForSeconds(1.2f);
            OWO.Send(relajación2, Muscle.Dorsal_R, Muscle.Dorsal_L, Muscle.Arm_L, Muscle.Arm_R);


            Debug.Log("Send Relajación");
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
