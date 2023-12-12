using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource backgroundMusic;
    public AudioSource soundEffect;

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

    // Add more functions as needed, such as volume control, fade in/out, etc.
}
