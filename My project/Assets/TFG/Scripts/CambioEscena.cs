using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class CambioEscena : MonoBehaviour
{
    public string nombreEscena;
    private XRController controller;
    private ActionBasedController actionBasedController;

    private void Start()
    {
        // Obtener el XRController adjunto a este objeto
        controller = GetComponent<XRController>();

        // Obtener el ActionBasedController directamente del objeto en el que está adjunto
        actionBasedController = GetComponent<ActionBasedController>();

        // Verificar si actionBasedController es nulo (no se pudo obtener del objeto actual)
        if (actionBasedController == null)
        {
            Debug.LogWarning("Este script requiere un ActionBasedController adjunto al mismo objeto.");
            return;
        }

        // Suscribirte al evento de entrada del botón primario del controlador
        actionBasedController.selectAction.action.performed += CambiarEscena;
    }

    private void OnDestroy()
    {
        // Asegúrate de limpiar la suscripción al destruir el objeto
        if (actionBasedController != null)
        {
            actionBasedController.selectAction.action.performed -= CambiarEscena;
        }
    }

    private void CambiarEscena(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // Cambiar la escena al presionar cualquier botón en el controlador
        SceneManager.LoadScene(nombreEscena);
    }
}
