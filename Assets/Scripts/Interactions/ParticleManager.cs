using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private static ParticleManager instance;

    public static ParticleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ParticleManager>();

                if (instance == null)
                {
                    GameObject singleton = new GameObject("ParticleManager");
                    instance = singleton.AddComponent<ParticleManager>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Play particle effect at a given position
    public void PlayParticleEffect(GameObject particlePrefab, Vector3 position)
    {
        GameObject particleInstance = Instantiate(particlePrefab, position, Quaternion.identity);
        ParticleSystem particles = particleInstance.GetComponent<ParticleSystem>();
        // Wait until the particle system has finished playing
        StartCoroutine(WaitForParticleCompletion(particles, particleInstance));
    }

    // Stop particle effect if it is currently playing
    public void StopParticleEffect(GameObject particleInstance)
    {
        if (particleInstance != null)
        {
            var particleSystem = particleInstance.GetComponent<ParticleSystem>();
            if (particleSystem != null && particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
        }
    }

    // Destroy particle effect immediately
    public void DestroyParticleEffect(GameObject particleInstance)
    {
        if (particleInstance != null)
        {
            Destroy(particleInstance);
        }
    }

    private IEnumerator WaitForParticleCompletion(ParticleSystem particles, GameObject particleInstance)
    {
        while (particles.isPlaying)
        {
            yield return null;
        }

        // Particle system has finished playing, destroy the particle effect
        DestroyParticleEffect(particleInstance);
    }
}
