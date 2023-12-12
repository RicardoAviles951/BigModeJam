using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject particlePrefab;
    public bool kill = false;
    public AudioClip explodeSound;
   

    // Update is called once per frame
    void Update()
    {
        if (kill)
        {
            KillBox();
            kill = false;
        }
    }

    public void KillBox()
    {
        ParticleManager.Instance.PlayParticleEffect(particlePrefab, transform.position);
        AudioManager.instance.PlaySoundEffect(explodeSound);
        Destroy(gameObject);
        
    }
}
