using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceAbility : AbilityBase
{
    private Color color = Color.blue;
    public override void Activate(AbilityManager ability)
    {
        Debug.Log("Ready to INFLUENCE: Looking for followers.");
        ability.color = color;
        
    }


    public override void UpdateAbility(AbilityManager ability)
    {
        //Checking for switch input (Left mouse button)
        if (ability.input._switch)
        {
            ability.ChangeAbility(ability.angerAbility);
        }
    }

    public override void SubscribedEvent(AbilityManager ability, CrowdlingBrain crowdling)
    {
            crowdling.ChangeColor(ability.color);
            crowdling.SwitchState(crowdling.followingState);
            Debug.Log("INFLUENCED");
    }

}
