using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingState : CrowdlingBaseState
{

    private Vector3 distanceBetween;
    private Vector3 normalizedDir;
    private bool move;
    private float maxDistance = 2.0f;
    private float moveSpeed;
    private Transform self;
    private Transform target;
    public override void EnterState(CrowdlingBrain crowdling)
    {
        Debug.Log("Follow State: Following something I think...");
        self   = crowdling.gameObject.transform;
        target = GameObject.FindWithTag("Follow Point").gameObject.transform;

        //If for some reason the player is not in the scene, the crowdling will return to waiting. 
        if(target == null)
        {
            crowdling.SwitchState(crowdling.waitingState);
        }
    }

    public override void UpdateState(CrowdlingBrain crowdling)
    {
        distanceBetween = target.position - self.position;
        normalizedDir = distanceBetween.normalized;
        Vector3 lookDir = new Vector3(normalizedDir.x, 0, normalizedDir.z);
        if (distanceBetween.magnitude > crowdling.ketchupDistance)
        {
            moveSpeed = crowdling.maxSpeed;
        }
        else
        {
            moveSpeed = crowdling.normalSpeed;
        }
        if (distanceBetween.magnitude >= maxDistance)
        {
            move = true;
        }
        else
        {
            move = false;
        }
        self.rotation = Quaternion.LookRotation(lookDir);
    }

    public override void UpdatePhysics(CrowdlingBrain crowdling)
    {
        if (move)
        {
            MoveToTarget(target, crowdling);
        }
    }

    public override void OnCollision(Collision collision, CrowdlingBrain crowdling)
    {

    }

    private void MoveToTarget(Transform target,CrowdlingBrain crowdling)
    {
        crowdling.rb.velocity = new Vector3(normalizedDir.x * moveSpeed, 0, normalizedDir.z * moveSpeed);
    }
}
