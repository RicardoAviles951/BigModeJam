using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifter : MonoBehaviour
{
    private Transform cubeTransform;
    [SerializeField] private bool isLifting = false;
    private Vector3 targetPosition;
    public List<AudioClip> joyfulLiftClips = new List<AudioClip>();
    public float liftHeight = 10f;
    private Rigidbody rb;

    void Start()
    {
        cubeTransform = transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isLifting)
        {
            
            // Smoothly move the cube towards the target position
            cubeTransform.position = Vector3.Lerp(cubeTransform.position, targetPosition, Time.deltaTime * 1f);

            // Check if the cube is close enough to the target position
            if (Vector3.Distance(cubeTransform.position, targetPosition) < 0.05f)
            {
                isLifting = false;
            }
        }

        
    }

    public void Lift()
    {
        rb.useGravity = false; 
        // Set the target position for lifting
        targetPosition = cubeTransform.position + Vector3.up * liftHeight;

        // Start lifting
        isLifting = true;
    }

    public void PlaySound()
    {
        Debug.Log("Playing Sound");
        int randInt = Random.Range(0,joyfulLiftClips.Count);
        AudioClip clip = joyfulLiftClips[randInt];

        AudioManager.instance.PlaySoundEffect(clip,.5f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        int layer = LayerMask.NameToLayer("Geometry");

        if(collision.gameObject.layer == layer)
        {
            Debug.Log("Lifter stopped");
            rb.velocity = Vector3.zero;
            isLifting = false;
        }
    }
}
