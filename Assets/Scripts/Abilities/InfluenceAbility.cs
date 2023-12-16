using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InfluenceAbility : AbilityBase
{
    private Color color = Color.blue;
    string name;
    public override void Activate(AbilityManager ability)
    {
        Debug.Log("Ready to INFLUENCE: Looking for followers.");
        ability.moodName = "Influence";
        ability.color = color;

        name = ability.moodName;
        //ability.moodRelay.ChangeText(name, color);
        ability.ChangeName(name, color, ability.defaultFont);
    }


    public override void UpdateAbility(AbilityManager ability)
    {

        //Checking for switch input(right mouse button)
        if (ability.input.next)
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
