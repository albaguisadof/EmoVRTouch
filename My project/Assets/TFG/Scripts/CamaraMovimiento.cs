using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CamaraMovimiento : MonoBehaviour
{
    public float velocidad = 6.5f;
    public float altura = 4f;
    private float tiempo = 0f;

    OWOScript owo = new OWOScript();
    public bool activarOWO = true;
    public AudioSource audio;

    private void Awake()
    {
        if (activarOWO)
        {
            owo.Start();
        }
        audio.Play();
    }

    private void Start()
    {
        transform.position = new Vector3(600, 22, 15);

        if (activarOWO)
        {
            StartCoroutine(owoSensación());
        }
    }

    IEnumerator owoSensación()
    {
        while (true)
        {
            StartCoroutine(owo.SendRelajación());
          
            yield return new WaitForSeconds(4.4f);
        }
        
    }

    void Update()
    {
        //Calculamos el tiemnpo
        tiempo += Time.deltaTime;
        if (tiempo < 60f)
        {
            //Desplazo en el terreno
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

            //Calculo la altura sobre el terreno
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                Vector3 posicionTerreno = hit.point;
                transform.position = new Vector3(transform.position.x, posicionTerreno.y + altura, transform.position.z);
            }
        }
        else if(tiempo >= 65f)
        {
            owo.Disconnect();
        }
        
    }
}
