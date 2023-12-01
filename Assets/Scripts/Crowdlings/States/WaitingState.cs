using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : CrowdlingBaseState
{
    public override void EnterState(CrowdlingBrain crowdling)
    {
        Debug.Log("Waiting State: Just sitting here...");
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
