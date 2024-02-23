using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovimiento2 : MonoBehaviour
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
        transform.position = new Vector3(580, 20, 260);

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
       

    }
}
