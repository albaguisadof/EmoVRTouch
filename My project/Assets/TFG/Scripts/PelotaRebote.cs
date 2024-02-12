using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaRebote : MonoBehaviour
{
    public float velocidadInicial = 8f;



    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.right * velocidadInicial;
        rb.drag = 0;
        rb.angularDrag = 0;

    }

  

    void Update()
    {
        
    }
}
