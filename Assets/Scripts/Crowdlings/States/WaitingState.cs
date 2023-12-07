using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : CrowdlingBaseState
{
    public override void EnterState(CrowdlingBrain crowdling)
    {
        Debug.Log("Waiting State: Just sitting here...");
        crowdling.rb.velocity = Vector3.zero;
        crowdling.transform.rotation = Quaternion.identity;
        crowdling.rb.freezeRotation = true;
        //crowdling.rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        crowdling.rb.constraints &= ~RigidbodyConstraints.FreezeRotationY;
        crowdling.ChangeColor(Color.white);
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
