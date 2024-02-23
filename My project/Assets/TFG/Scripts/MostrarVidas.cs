using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarVidas : MonoBehaviour
{
    public Image estrellaPrefab; // Asigna tu sprite de estrella aquí
    public Transform contenedorEstrellas; // Asigna un objeto para contener las estrellas en tu escena

    // Lista para almacenar referencias a las estrellas creadas
    private List<Image> estrellasCreadas = new List<Image>();

    void Start()
    {
        // Suscribirse al evento de cambio de vidas
        Jugador.Instance.VidasChangedEvent += ActualizarEstrellas;

        // Inicializar la representación gráfica de las estrellas
        ActualizarEstrellas(Jugador.Instance.ObtenerVidas());
    }

    
        void ActualizarEstrellas(int nuevasVidas)
        {
            // Limpiar todas las estrellas creadas anteriormente
            foreach (Image estrella in estrellasCreadas)
            {
                Destroy(estrella.gameObject);
            }
            estrellasCreadas.Clear();

            // Mostrar nuevas estrellas según el número de vidas
            for (int i = 0; i < nuevasVidas; i++)
            {
                // Crear una nueva estrella
                Image nuevaEstrella = Instantiate(estrellaPrefab, contenedorEstrellas);

            // Ajustar la posición
            nuevaEstrella.rectTransform.localPosition = new Vector3((i * 70) - (nuevasVidas *20), 0, 0);
                   // nuevaEstrella.rectTransform.localPosition = new Vector3(0, 0, 0);

                // Agregar referencia a la lista
                estrellasCreadas.Add(nuevaEstrella);
            }
        }
    /*
        void ActualizarEstrellas(int nuevasVidas)
        {
            // Mostrar nuevas estrellas según el número de vidas
            for (int i = 0; i < nuevasVidas; i++)
            {
                // Crear una nueva estrella
                Image nuevaEstrella = Instantiate(estrellaPrefab, contenedorEstrellas);
                estrellasCreadas.Add(nuevaEstrella); // Agregar referencia a la lista
                nuevaEstrella.enabled = true;

                // Ajustar la posición
                Vector3 nuevaPosicion = nuevaEstrella.rectTransform.position;
                nuevaPosicion.z = i;
                nuevaEstrella.rectTransform.position = new Vector3(-5.7f, 3.5f, i - 0.5f);

                estrellaPrefab.enabled = false;
            }

            // Limpiar referencias a estrellas que ya no se deben mostrar
            for (int i = nuevasVidas; i < estrellasCreadas.Count; i++)
            {
                Destroy(estrellasCreadas[i].gameObject);
            }

            // Mantener solo las referencias de las estrellas que todavía están en la pantalla
            estrellasCreadas.RemoveRange(nuevasVidas, estrellasCreadas.Count - nuevasVidas);
        }

    void ActualizarEstrellas(int nuevasVidas)
    {
        // Mostrar nuevas estrellas según el número de vidas
        for (int i = 0; i < nuevasVidas; i++)
        {
            // Verificar si ya existe una estrella en esta posición
            if (i < estrellasCreadas.Count)
            {
                // Activar la estrella existente
                estrellasCreadas[i].enabled = true;
            }
            else
            {
                // Crear una nueva estrella
                Image nuevaEstrella = Instantiate(estrellaPrefab, contenedorEstrellas);
                estrellasCreadas.Add(nuevaEstrella); // Agregar referencia a la lista

                // Ajustar la posición de la nueva estrella
                nuevaEstrella.rectTransform.anchoredPosition = new Vector2(i * 50, 0);
            }
        }

        // Ocultar las estrellas restantes que no se deben mostrar
        for (int i = nuevasVidas; i < estrellasCreadas.Count; i++)
        {
            estrellasCreadas[i].enabled = false;
        }
    }*/
}
