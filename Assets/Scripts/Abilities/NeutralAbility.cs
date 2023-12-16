using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralAbility : AbilityBase
{
    private Color color = Color.black;
    private Color neutralColor = Color.white;
    string name;
    public override void Activate(AbilityManager ability)
    {
        Debug.Log("NEUTRAL: Not feeling much...");
        ability.moodName = "Neutral";
        ability.color = color;

        name = ability.moodName;
        color = ability.color;
        //ability.moodRelay.ChangeText(name, neutralColor);
        ability.ChangeName(name, neutralColor, ability.defaultFont);
    }

    public override void SubscribedEvent(AbilityManager ability, CrowdlingBrain crowdling)
    {
        crowdling.ChangeColor(neutralColor);
        crowdling.currentMood = CrowdlingBrain.mood.neutral;
        crowdling.SwitchState(crowdling.waitingState);
    }

    public override void UpdateAbility(AbilityManager ability)
    {
        //Checking for switch input(Left mouse button)
        if (ability.input.next)
        {
            ability.ChangeAbility(ability.InfluenceAbility);
        }
    }
}
