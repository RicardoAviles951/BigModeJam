using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleBrain : MonoBehaviour
{
    public ParticleManager particleManager;

    private void Start()
    {
        particleManager.SpawnParticle(transform.position);
    }

    private void Update()
    {
        
    }

    public void PlayParticles()
    {
        particleManager.PlayParticle();
    }

    private void DestroyOnFinish()
    {
        
    }

    public void DestroyParent()
    {
        Destroy(gameObject);
    }


}
