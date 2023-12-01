using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CrowdlingBaseState
{
    public abstract void EnterState(CrowdlingBrain crowdling);
    public abstract void UpdateState(CrowdlingBrain crowdling);
    public abstract void UpdatePhysics(CrowdlingBrain crowdling);
    public abstract void OnCollision(Collision collision, CrowdlingBrain crowdling);
}
