using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource backgroundMusic;
    public AudioSource soundEffect;

    public AudioClip startingMusic;
    public float volume = .50f;

    // Add a reference to the duration of the fade-in
    public float fadeInDuration = 2.0f;

    // Add a flag to check if the music is currently fading in
    private bool isFadingIn = false;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayBackgroundMusicWithFadeIn(startingMusic, volume);
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        backgroundMusic.clip = clip;
        backgroundMusic.loop = true;
        backgroundMusic.Play();
    }

    public void PlaySoundEffect(AudioClip clip, float volume = 1.0f)
    {
        soundEffect.clip = clip;
        soundEffect.volume = volume;
        soundEffect.Play();
    }

    public void StopBackgroundMusic()
    {
        backgroundMusic.Stop();
    }

    public void PlayBackgroundMusicWithFadeIn(AudioClip clip, float volume = 1f)
    {
        // Stop any ongoing fading in or playing
        StopCoroutine("FadeInMusic");
        StopBackgroundMusic();

        // Start fading in the music
        StartCoroutine(FadeInMusic(clip, volume));
    }

    private IEnumerator FadeInMusic(AudioClip clip, float maxVolume = 1f)
    {
        // Set the flag to indicate that fading in is in progress
        isFadingIn = true;

        // Cross-fade duration in seconds
        float fadeDuration = fadeInDuration;

        // Ensure volume is zero initially
        backgroundMusic.volume = 0f;

        // Set the new clip
        backgroundMusic.clip = clip;
        backgroundMusic.loop = true;
        backgroundMusic.Play();

        // Gradually increase the volume
        while (backgroundMusic.volume < maxVolume)
        {
            backgroundMusic.volume += Time.deltaTime / fadeDuration;
            yield return null;
        }

        // Set the volume to exactly 1.0 to avoid rounding errors
        backgroundMusic.volume = maxVolume;

        // Reset the flag
        isFadingIn = false;
    }

    // Add more functions as needed, such as volume control, fade in/out, etc.
}
