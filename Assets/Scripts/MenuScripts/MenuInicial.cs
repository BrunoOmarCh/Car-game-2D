using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public GameObject MenuOpciones;
    AudioManager audioManager;

    void Start()
    {
        MenuOpciones.SetActive(false);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); // Encuentra el AudioManager y reproduce la música de fondo correctamente.
        audioManager.musicSource.clip = audioManager.menu; // Asigna el clip al musicSource.
        audioManager.musicSource.Play(); // Reproduce la música de fondo.
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
