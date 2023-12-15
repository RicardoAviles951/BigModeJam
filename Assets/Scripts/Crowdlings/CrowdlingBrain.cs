using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CrowdlingBrain : MonoBehaviour, IAfflictable
{
    public enum mood
    {
        neutral,
        angry,
        joyful
    }

    public mood currentMood;
    CrowdlingBaseState currentState;
    public WaitingState waitingState     = new WaitingState();
    public FollowingState followingState = new FollowingState();
    public FleeingState fleeingState     = new FleeingState();
    public FlingState flingState         = new FlingState();
    
    //Hidden fields
    [HideInInspector] public Rigidbody rb;
    private Renderer renderer;
    [HideInInspector] public bool afflicted = false;
    [HideInInspector] public Animator anim;

    [Header("Following Around")]
    public float normalSpeed = 2.0f;
    public float maxSpeed = 6.0f;
    public float ketchupDistance = 6.0f;
    public AudioClip alertSound;
    [HideInInspector] public NavMeshAgent navAgent;

    [Header("Flinging Around")]
    public float flingForce = 20f;
    public AudioClip angrySound;
    public AudioClip joySound;
    public AudioClip flingSound;
    public float stunDuration;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
        currentState = waitingState;
        currentMood = mood.neutral;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState.UpdatePhysics(this);   
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollision(collision, this);

    }

    public void SwitchState(CrowdlingBaseState crowdling)
    {
        if(currentState != crowdling)
        {
            currentState = crowdling;
            ToggleNav(false);
            crowdling.EnterState(this);
        }
        else
        {
            Debug.Log("Already in this state: " + currentState);    
        }
        
        
    }

    public void ChangeColor(Color color)
    {
        renderer.material.color = color;
        Debug.Log("AFFLICTED");
    }

    public void MoodSound(AudioClip sound, float vol = 1)
    {
        AudioManager.instance.PlaySoundEffect(sound, vol);
        anim.SetTrigger("alert");
    }


    public CrowdlingBaseState GetState()
    {
        return currentState;
    }

    public void ToggleNav(bool nav)
    {
        navAgent.enabled = nav;
    }
    
}
