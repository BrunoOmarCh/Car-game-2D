using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public GameObject MenuOpciones;
    void Start()
    {
        MenuOpciones.SetActive(false);
    }

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Opciones() { 
        MenuOpciones.SetActive(true);
        Debug.Log("Opciones");
    }

    public void Salir() {
        Debug.Log("Salir...");
        Application.Quit();
    
    }
}
