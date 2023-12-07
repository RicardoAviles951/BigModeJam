using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

[CreateAssetMenu(fileName = "ParticleManager")]
public class ParticleManager : ScriptableObject
{
    public ParticleSystem particlePrefab;
    private ParticleSystem particleInstance;
    

    public ParticleSystem SpawnParticle(Vector3 position)
    {
        particleInstance = Instantiate(particlePrefab,position, Quaternion.identity);
        return particleInstance;
    }

    public void PlayParticle()
    {
        particleInstance.Play();
    }

    public void DestroyParticle(GameObject particle)
    {
        
    }

    public void DestroyParticleOnComplete()
    {
        if (particleInstance != null)
        {
            if(!particleInstance.isPlaying)
            {
                Debug.Log("Finished Playing");
                Destroy(particleInstance);
            }
        }
    }
}
