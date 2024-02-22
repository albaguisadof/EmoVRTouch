using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class FinalizarJuego : MonoBehaviour
{
    private XRController controller;
    private ActionBasedController actionBasedController;

    private void Start()
    {
        controller = GetComponent<XRController>();
        actionBasedController = GetComponent<ActionBasedController>();

        if (actionBasedController == null)
        {
            Debug.LogWarning("Este script requiere un ActionBasedController adjunto al mismo objeto.");
            return;
        }

        // Suscribirte al evento de entrada del botón primario del controlador
        actionBasedController.selectAction.action.performed += Terminar;
    }

    private void OnDestroy()
    {
        // Eliminar la suscripción al destruir el objeto
        if (actionBasedController != null)
        {
            actionBasedController.selectAction.action.performed -= Terminar;
        }
    }

    private void Terminar(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}
