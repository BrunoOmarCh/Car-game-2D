using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    public void Start() {
        if (PlayerPrefs.HasKey("musicVolumen"))
        {
            LoalVolumen();
        }
        else
        {
            SetMusicVolumen();
            SetSFXVolumen();
        }
    }

    public void SetMusicVolumen() { 
        float volumen = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volumen)*20);
        PlayerPrefs.SetFloat("musicVolumen", volumen );
    }

    public void SetSFXVolumen()
    {
        float volumen = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volumen) * 20);
        PlayerPrefs.SetFloat("SFXVolumen", volumen);
    }

    private void LoalVolumen()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolumen");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolumen");
        SetMusicVolumen();
        SetSFXVolumen();
    }




}
