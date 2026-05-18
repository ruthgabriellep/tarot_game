using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")] [SerializeField]
    private AudioSource musicSource;

    [SerializeField] private AudioSource sfxSource;
    
    [SerializeField] private AudioSource ambienceSource;

    [Header("Starting Music")] [SerializeField]
    private AudioClip background;

    [Header("Settings")] [SerializeField] private float fadeDuration = 1.5f;

    public static AudioManager Instance;

    private Coroutine musicFadeCoroutine;
    
    [Range(0f, 1f)]
    [SerializeField] private float musicVolume = 1f;

    [Range(0f, 1f)]
    [SerializeField] private float sfxVolume = 1f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayMusic(background);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;

        if (musicSource.clip == clip && musicSource.isPlaying)
            return;

        // musicSource.clip = clip;
        // musicSource.loop = true;
        // musicSource.Play();

        if (musicFadeCoroutine != null)
        {
            StopCoroutine(musicFadeCoroutine);
        }

        musicFadeCoroutine = StartCoroutine(FadeMusic(clip));
    }

    IEnumerator FadeMusic(AudioClip newClip)
    {
        // fade OUT
        while (musicSource.volume > 0)
        {
            musicSource.volume -= Time.deltaTime / fadeDuration;
            yield return null;
        }

        musicSource.Stop();
        
        musicSource.clip = newClip;
        musicSource.loop = true;
        
        musicSource.volume = 0f;
        
        musicSource.Play();
        
        while (musicSource.volume < musicVolume)
        {
            musicSource.volume += Time.deltaTime / fadeDuration;
            yield return null;
        }

        musicSource.volume = musicVolume;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;

        sfxSource.PlayOneShot(clip);
    }
    
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        sfxSource.volume = volume;
    }
    
    public void StopSFX()
    {
        sfxSource.Stop();
    }
    
    public void PlayAmbience(AudioClip clip)
    {
        if (clip == null) return;

        if (ambienceSource.clip == clip && ambienceSource.isPlaying)
            return;

        ambienceSource.clip = clip;
        ambienceSource.loop = true;
        ambienceSource.Play();
    }

    public void StopAmbience()
    {
        ambienceSource.Stop();
    }
    
}
