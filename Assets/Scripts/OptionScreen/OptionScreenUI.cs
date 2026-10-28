using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionScreenUI : MonoBehaviour
{
    public AudioMixer mainAudioMixer;
    
    public Slider mainMasterSlider;
    public Slider musicVolumeSlider;
    public Slider SFXVolumeSlider;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnMainVolumeChange();
        OnMusicVolumeChange();
        OnSFXVolumeChange();
    }

    public void OnMainVolumeChange ()
    {
        // Starts with slider value
        float newVolume = mainMasterSlider.value;
        if(newVolume <= 0)
        {
            // If 0, set volume to lowest value
            newVolume = -80;
        }
        else
        {
            // Greater than 0, find log10 value, and make it in the 0 - 20 decibel range
            newVolume = Mathf.Log10(newVolume);
            newVolume = newVolume * 20;
        }
        // Set volume to the new setting
        mainAudioMixer.SetFloat("MasterVolume", newVolume);
    }

    public void OnMusicVolumeChange ()
    {
        // Starts with slider value
        float newVolume = musicVolumeSlider.value;
        if(newVolume <= 0)
        {
            // If 0, set volume to lowest value
            newVolume = -80;
        }
        else
        {
            // Greater than 0, find log10 value, and make it in the 0 - 20 decibel range
            newVolume = Mathf.Log10(newVolume);
            newVolume = newVolume * 20;
        }
        // Set volume to the new setting
        mainAudioMixer.SetFloat("BackgroundMusicVolume", newVolume);
    }

    public void OnSFXVolumeChange ()
    {
        // Starts with slider value
        float newVolume = SFXVolumeSlider.value;
        if(newVolume <= 0)
        {
            // If 0, set volume to lowest value
            newVolume = -80;
        }
        else
        {
            // Greater than 0, find log10 value, and make it in the 0 - 20 decibel range
            newVolume = Mathf.Log10(newVolume);
            newVolume = newVolume * 20;
        }
        // Set volume to the new setting
        mainAudioMixer.SetFloat("SFXVolume", newVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
