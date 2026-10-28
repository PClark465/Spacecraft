using UnityEngine;
using UnityEngine.Audio;

public class GameAudio : MonoBehaviour
{
    public static GameAudio instance;
    // Headers created for all audio sources, mixer groups, and sounds
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Mixer Groups")]
    public AudioMixerGroup musicGroup;
    public AudioMixerGroup sfxGroup;

    [Header("Background Music")]
    public AudioClip backgroundMusic;

    [Header("Laser Sound Effects")]
    public AudioClip laserShot;
    public AudioClip laserImpact;

    [Header("Enemy Engine Noise")]
    public AudioClip engineHum;

    [Header("Enemy Sound Effects")]
    public AudioClip boomEffect;
    public AudioClip staticHum;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Checks to see if the music exists
        if(musicSource != null)
        {
            // Sets up the background music to be sound clip that plays on loop
            musicSource.outputAudioMixerGroup = musicGroup;
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            if(backgroundMusic != null && !musicSource.isPlaying)
            {
                musicSource.Play();
            }
        }
        // Checks for the SFX source if it exists
        if(sfxSource != null)
        {
            sfxSource.outputAudioMixerGroup = sfxGroup;
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if(clip != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlaySFXAtPoint(AudioClip clip, Vector3 position)
    {
        if(clip == null)
        {
            return;
        }

        GameObject soundObject = new GameObject("TemporarySFX");
        soundObject.transform.position = position;

        AudioSource source =
            soundObject.AddComponent<AudioSource>();
        
        source.outputAudioMixerGroup = sfxGroup;
        source.spatialBlend = 1f;
        source.PlayOneShot(clip);

        Destroy(soundObject, clip.length + 0.1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
