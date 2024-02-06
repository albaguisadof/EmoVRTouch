using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    string filename = "";
    public string jugador = "";

    [System.Serializable]
    public class Pelota
    {
        public double velocidad;
        public string posición;
        public double tiempo;
        public bool colisión;
    }

    [System.Serializable]
    public class PelotaList
    {
        public List<Pelota> lista;
    }

    public PelotaList pelotas = new PelotaList();
    public Pelota nuevaPelota = new Pelota();

    // Start is called before the first frame update
    void Start()
    {
        filename = Application.dataPath + "/TFG/Resultados/" + jugador + ".csv";
        pelotas.lista = new List<Pelota>();
        //WriteCSV();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteCSV()
    {
        TextWriter textWriter = new StreamWriter(filename, false);
        textWriter.WriteLine("NumPelota, Velocidad, Posición, Tiempo, Colisión");
        if (pelotas.lista.Count > 0)
        {
           

            for(int i = 0; i < pelotas.lista.Count; i++)
            {
                textWriter.WriteLine(i.ToString() , pelotas.lista[i].velocidad ,
                    pelotas.lista[i].posición , pelotas.lista[i].tiempo, pelotas.lista[i].colisión);
            }
            textWriter.Close();
        }
        
    }
}
