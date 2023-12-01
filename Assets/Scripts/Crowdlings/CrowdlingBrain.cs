using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdlingBrain : MonoBehaviour
{
    CrowdlingBaseState currentState;
    public WaitingState waitingState     = new WaitingState();
    public FollowingState followingState = new FollowingState();
    public FleeingState fleeingState     = new FleeingState();
    //Hidden fields
    [HideInInspector] public Rigidbody rb;


    [Header("Waiting Around")]

    [Header("Following Around")]
    public float normalSpeed = 2.0f;
    public float maxSpeed = 6.0f;
    public float ketchupDistance = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentState = followingState;
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
}
