using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.CloudSave.Models;
using Unity.Services.Core;

public class SubirResultados : MonoBehaviour
{
    private async void Awake()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void SavePlayerFile(string rutaArchivo)
    {
        try
        {
            List<Unity.Services.CloudSave.Models.FileItem> files = await CloudSaveService.Instance.Files.Player.ListAllAsync();
            string nombreArchivo = files.Count.ToString();
            byte[] file = System.IO.File.ReadAllBytes(rutaArchivo);
            await CloudSaveService.Instance.Files.Player.SaveAsync(nombreArchivo, file);

            Debug.Log("Archivo guardado correctamente.");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al guardar el archivo: " + ex.Message + ex.StackTrace);
        }
    }
    
}
