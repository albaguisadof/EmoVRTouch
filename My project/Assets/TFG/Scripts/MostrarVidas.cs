using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarVidas : MonoBehaviour
{
    public Image estrellaPrefab; // Asigna tu sprite de estrella aqu�
    public Transform contenedorEstrellas; // Asigna un objeto para contener las estrellas en tu escena

    // Lista para almacenar referencias a las estrellas creadas
    private List<Image> estrellasCreadas = new List<Image>();

    void Start()
    {
        // Suscribirse al evento de cambio de vidas
        Jugador.Instance.VidasChangedEvent += ActualizarEstrellas;

        // Inicializar la representaci�n gr�fica de las estrellas
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

        // Mostrar nuevas estrellas seg�n el n�mero de vidas
        for (int i = 0; i < nuevasVidas; i++)
        {
            // Crear una nueva estrella
            Image nuevaEstrella = Instantiate(estrellaPrefab, contenedorEstrellas);

        // Ajustar la posici�n
        nuevaEstrella.rectTransform.localPosition = new Vector3((i * 70) - (nuevasVidas *20), 0, 0);
                // nuevaEstrella.rectTransform.localPosition = new Vector3(0, 0, 0);

            // Agregar referencia a la lista
            estrellasCreadas.Add(nuevaEstrella);
        }
    }
   
}
