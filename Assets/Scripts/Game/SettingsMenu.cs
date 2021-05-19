using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    //Adrián
    public Slider slider;
    public float volumeValue;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
    }
    public void ControlVolume(float volume)
    {
        volumeValue = volume;
        PlayerPrefs.GetFloat("volumenAudio", volumeValue);
        AudioListener.volume = slider.value;
    }
}

