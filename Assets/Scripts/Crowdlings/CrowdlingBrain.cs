using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    [Header("Following Around")]
    public float normalSpeed = 2.0f;
    public float maxSpeed = 6.0f;
    public float ketchupDistance = 6.0f;

    [Header("Flinging Around")]
    public float flingForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        rb = GetComponent<Rigidbody>();
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
        currentState = crowdling;
        crowdling.EnterState(this);
    }

    public void ChangeColor(Color color)
    {
        renderer.material.color = color;
        Debug.Log("AFFLICTED");
    }

    public CrowdlingBaseState GetState()
    {
        return currentState;
    }
    
}
