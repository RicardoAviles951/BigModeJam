using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlingState : CrowdlingBaseState
{
    public override void EnterState(CrowdlingBrain crowdling)
    {
        Debug.Log("FLING!");
        Vector3 lookDir = crowdling.transform.forward;
        
        Vector3 flingForce = new Vector3(0, 0, lookDir.z);
        
        crowdling.rb.AddForce(lookDir*crowdling.flingForce, ForceMode.Impulse);
    }

    public override void OnCollision(Collision collision, CrowdlingBrain crowdling)
    {
        
        if(collision.gameObject.tag == "Breakable")
        {
            Debug.Log("Hit wall");
            switch (crowdling.currentMood)
            {
                case CrowdlingBrain.mood.neutral:
                    Debug.Log("boop");
                    break;

                case CrowdlingBrain.mood.angry:
                    Debug.Log("BOOM");
                    ParticleBrain particle = collision.gameObject.GetComponent<ParticleBrain>();
                    particle.PlayParticles();
                    particle.DestroyParent();
                    crowdling.SwitchState(crowdling.waitingState);
                    break;

                case CrowdlingBrain.mood.joyful:
                    Debug.Log("Up up and away");
                    Lifter lifter = collision.gameObject.GetComponent<Lifter>();
                    lifter.Lift(5f);
                    crowdling.SwitchState(crowdling.waitingState);
                    break;
            }
            
            
        }
    }

    public override void UpdatePhysics(CrowdlingBrain crowdling)
    {
        
    }

    public override void UpdateState(CrowdlingBrain crowdling)
    {
        
    }
}
