using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("------Audio Source------")]
    [SerializeField] public AudioSource musicSource; // Audio para la música.
    [SerializeField] public AudioSource SFXSource;  // Audio para efectos de sonido.

    [Header("------Audio Clip--------")]
    //Musica de dondo
    public AudioClip menu;
    public AudioClip background;

    //Effectos de sonidos
    public AudioClip death;
    public AudioClip coins;
    public AudioClip live;
    public AudioClip crash;
    public AudioClip boom;
    public AudioClip win;

    public void Start()
    {
        /* La música de fondo no se configura:  audioSource.start() pero si queremos 
         hacer musica en distintos niveles */
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void ResumeMusic()
    {
        musicSource.UnPause();
    }
}
