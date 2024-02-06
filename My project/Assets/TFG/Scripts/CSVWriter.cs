using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Pelota: MonoBehaviour
{
    public double velocidad;
    public string posición;
    public double tiempo;
    public bool colisión;
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
        textWriter.WriteLine("NumPelota, Velocidad, Posición, Tiempo, Colisión");
        if (pelotas.Count > 0)
        {
            for(int i = 0; i < pelotas.Count; i++)
            {
                textWriter.WriteLine(i.ToString() + "," + pelotas[i].velocidad.ToString() + "," +
                    pelotas[i].posición.ToString() + "," + pelotas[i].tiempo.ToString() + "," + pelotas[i].colisión.ToString());
            }
            textWriter.Close();
        }
        
    }
}
