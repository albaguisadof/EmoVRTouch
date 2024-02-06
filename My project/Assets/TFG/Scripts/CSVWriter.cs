using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Pelota: MonoBehaviour
{
    public double velocidad;
    public string posici�n;
    public double tiempo;
    public bool colisi�n;
}

public class CSVWriter : MonoBehaviour
{
    string filename = "";
    public string jugador = "";

    public List<Pelota> pelotas;

    // Start is called before the first frame update
    void Start()
    {
        filename = Application.dataPath + "/TFG/Resultados/" + jugador + ".csv";
        Debug.Log(filename);
        //WriteCSV();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteCSV()
    {
        TextWriter textWriter = new StreamWriter(filename, false);
        textWriter.WriteLine("NumPelota, Velocidad, Posici�n, Tiempo, Colisi�n");
        if (pelotas.Count > 0)
        {
            for(int i = 0; i < pelotas.Count; i++)
            {
                textWriter.WriteLine(i.ToString() + "," + pelotas[i].velocidad.ToString() + "," +
                    pelotas[i].posici�n.ToString() + "," + pelotas[i].tiempo.ToString() + "," + pelotas[i].colisi�n.ToString());
            }
            textWriter.Close();
        }
        
    }
}
