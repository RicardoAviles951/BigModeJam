using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    
    private AbilityManager abilityManager;
    
    

    private void Awake()
    {
        abilityManager = GetComponentInParent<AbilityManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CrowdlingBrain crowdling = other.GetComponent<CrowdlingBrain>();
        if (crowdling != null)
        {
            
            abilityManager.Execute(abilityManager, crowdling);
            
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    
}
