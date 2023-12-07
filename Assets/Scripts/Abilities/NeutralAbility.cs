using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralAbility : AbilityBase
{
    private Color color = Color.black;
    public override void Activate(AbilityManager ability)
    {
        Debug.Log("NEUTRAL: Not feeling much...");
        ability.color = color;
    }

    public override void SubscribedEvent(AbilityManager ability, CrowdlingBrain crowdling)
    {
        crowdling.ChangeColor(ability.color);
        crowdling.currentMood = CrowdlingBrain.mood.neutral;
        crowdling.SwitchState(crowdling.waitingState);
    }

    public override void UpdateAbility(AbilityManager ability)
    {
        //Checking for switch input (Left mouse button)
        if (ability.input._switch)
        {
            ability.ChangeAbility(ability.InfluenceAbility);
        }
    }
}
