using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionScreenUI : MonoBehaviour
{
    [Header("Audio Mixer")]
    public AudioMixer mainAudioMixer;
    
    [Header("Volume Sliders")]
    public Slider mainMasterSlider;
    public Slider musicVolumeSlider;
    public Slider SFXVolumeSlider;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Previously saved volumes load
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);  // Retrieves saved value
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // Update sliders without event triggers
        mainMasterSlider.SetValueWithoutNotify(masterVolume);
        musicVolumeSlider.SetValueWithoutNotify(musicVolume);
        SFXVolumeSlider.SetValueWithoutNotify(sfxVolume);

        // Apply loaded volumes
        ApplyVolume("MasterVolume", masterVolume);
        ApplyVolume("BackgroundMusicVolume", musicVolume);
        ApplyVolume("SFXVolume", sfxVolume);
    }

    public void OnMainVolumeChange ()
    {
        float volume = mainMasterSlider.value;

        ApplyVolume("MasterVolume", volume);

        PlayerPrefs.SetFloat("MasterVolume", volume);   // Stores selected value
        PlayerPrefs.Save(); // Writes to storage
    }

    public void OnMusicVolumeChange ()
    {
        float volume = musicVolumeSlider.value;

        ApplyVolume("BackgroundMusicVolume", volume);

        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public void OnSFXVolumeChange ()
    {
        float volume = SFXVolumeSlider.value;

        ApplyVolume("SFXVolume", volume);

        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }

    private void ApplyVolume(string parameter, float volume)
    {
        // Converts slider value (0-1) to decibels
        float decibels = volume <= 0.0001f
            ? -80f
            : Mathf.Log10(volume) * 20f;

        mainAudioMixer.SetFloat(parameter, decibels);
    }
}
