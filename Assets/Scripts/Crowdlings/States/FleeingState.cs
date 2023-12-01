using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeingState : CrowdlingBaseState
{
    public override void EnterState(CrowdlingBrain crowdling)
    {
        Debug.Log("Fleeing State: MOVING AWAY!");
    }

    public override void OnCollision(Collision collision, CrowdlingBrain crowdling)
    {

    }

    public override void UpdatePhysics(CrowdlingBrain crowdling)
    {

    }

    public override void UpdateState(CrowdlingBrain crowdling)
    {

    }
}
