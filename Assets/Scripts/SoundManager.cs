using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    //Checks to see if any volume changes have been made to load
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            Load();
        }
    }

    //Controls volume slider
    public void ChangeVolume()
    {
        //Value of sound is equal to value of current slider setting
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    //load volume setting between sessions
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    //Save volume settings between sessions
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
