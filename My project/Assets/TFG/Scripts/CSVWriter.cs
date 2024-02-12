using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditorInternal;

public class Pelota: MonoBehaviour
{
    public string tipo;
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

    private int totalPelotas = 0;
    private int pelotasColisionadas = 0;
    private int pelotasColisionadasIzq = 0;
    private int pelotasColisionadasDer = 0;
    private int pelotasEsquivadas = 0;
    private int pelotasEsquivadasIzq = 0;
    private int pelotasEsquivadasDer = 0;
    private int totalPuntosExtra = 0;
    private int puntosExtraObtenidos = 0;
    private int puntosExtraObtenidosIzq = 0;
    private int puntosExtraObtenidosDer = 0;
    private int puntosExtraEsquivados = 0;
    private int puntosExtraEsquivadosIzq = 0;
    private int puntosExtraEsquivadosDer = 0;


    void Start()
    {
        filename = Application.dataPath + "/TFG/Resultados/" + jugador + ".csv";
    }


    public void WriteCSV()
    {
        TextWriter textWriter = new StreamWriter(filename, false);
        textWriter.WriteLine("Tipo, Velocidad, Posición, Tiempo, Colisión");
        if (pelotas.Count > 0)
        {
            for(int i = 0; i < pelotas.Count; i++)
            {
                textWriter.WriteLine(pelotas[i].tipo + "," + pelotas[i].velocidad.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) 
                    + "," + pelotas[i].posición + "," + pelotas[i].tiempo.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) 
                    + "," + pelotas[i].colisión.ToString());

                if (pelotas[i].tipo == "Pelota")
                {
                    totalPelotas++;
                    if (pelotas[i].colisión)
                    {
                        pelotasColisionadas++;
                        if (pelotas[i].posición == "Derecha")
                        {
                            pelotasColisionadasDer++;
                        }
                        else
                        {
                            pelotasColisionadasIzq++;
                        }
                    }
                    else
                    {
                        pelotasEsquivadas++;
                        if (pelotas[i].posición == "Derecha")
                        {
                            pelotasEsquivadasDer++;
                        }
                        else
                        {
                            pelotasEsquivadasIzq++;
                        }
                    }
                }
                else if (pelotas[i].tipo == "Punto Extra")
                {
                    totalPuntosExtra++;
                    if (pelotas[i].colisión)
                    {
                        puntosExtraObtenidos++;
                        if (pelotas[i].posición == "Derecha")
                        {
                            puntosExtraObtenidosDer++;
                        }
                        else
                        {
                            puntosExtraObtenidosIzq++;
                        }
                    }
                    else
                    {
                        puntosExtraEsquivados++;
                        if (pelotas[i].posición == "Derecha")
                        {
                            puntosExtraEsquivadosDer++;
                        }
                        else
                        {
                            puntosExtraEsquivadosIzq++;
                        }
                    }
                }
            }

            textWriter.WriteLine(" ");

            textWriter.WriteLine("PELOTAS RECIBIDAS: , " + totalPelotas + "," + (totalPelotas / (double)pelotas.Count) * 100 + "%");
            textWriter.WriteLine(", Aciertos: , " + pelotasEsquivadas + ", Derecha: , " + pelotasEsquivadasDer + ", Izquierda: ," + pelotasEsquivadasIzq);

            if (pelotasEsquivadas > 0)
            {
                textWriter.WriteLine(", , " + (pelotasEsquivadas / (double)totalPelotas) * 100 + "% , , " + (pelotasEsquivadasDer / (double)pelotasEsquivadas) * 100 +
               "%, ," + (pelotasEsquivadasIzq / (double)pelotasEsquivadas) * 100 + "%");
            }
          

            textWriter.WriteLine(", Errores: , " + pelotasColisionadas + ", Derecha: , " + pelotasColisionadasDer + ", Izquierda: ," + pelotasColisionadasIzq);
            if (pelotasColisionadas > 0)
            {
                textWriter.WriteLine(", , " + (pelotasColisionadas / (double)totalPelotas) * 100 + "% , , " + (pelotasColisionadasDer / (double)pelotasColisionadas) * 100 +
                "%, ," + (pelotasColisionadasIzq / (double)pelotasColisionadas) * 100 + "%");

            }

            if (totalPuntosExtra > 0)
            {
                textWriter.WriteLine(" ");
                textWriter.WriteLine("PUNTOS EXTRAS RECIBIDOS: , " + totalPuntosExtra + "," + (totalPuntosExtra/ (double)pelotas.Count)*100 + "%");
                textWriter.WriteLine(", Obtenidos: , " + puntosExtraObtenidos + ", Derecha: , " + puntosExtraObtenidosDer, ", Izquierda: ," + puntosExtraObtenidosIzq);
                if(puntosExtraObtenidos > 0)
                {
                    textWriter.WriteLine(", , " + (puntosExtraObtenidos / (double)totalPuntosExtra) * 100 + "% , , " + (puntosExtraObtenidosDer / (double)puntosExtraObtenidos) * 100 +
                   "%, ," + (puntosExtraObtenidosIzq / (double)puntosExtraObtenidos) * 100 + "%");
                }
               
                textWriter.WriteLine(", Esquivados: , " + puntosExtraEsquivados + ", Derecha: , " + puntosExtraEsquivadosDer + ", Izquierda: ," + puntosExtraEsquivadosIzq);
                if(puntosExtraEsquivados > 0)
                {
                    textWriter.WriteLine(", , " + (puntosExtraEsquivados / (double)totalPuntosExtra) * 100 + "% , , " + (puntosExtraEsquivadosDer / (double)puntosExtraEsquivados) * 100 +
                    "%, ," + (puntosExtraEsquivadosIzq / (double)puntosExtraEsquivados) * 100 + "%");
                }
                
            }

            textWriter.WriteLine(" ");
            textWriter.WriteLine("PUNTOS FINALES:, " + Jugador.Instance.vidas);
            textWriter.WriteLine(" ");
            textWriter.WriteLine("OWO: ," + Jugador.Instance.activarOWO);

            textWriter.Close();
        }
        
    }
}
