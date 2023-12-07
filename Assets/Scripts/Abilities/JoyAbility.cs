using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyAbility : AbilityBase
{
    Color color = Color.green;
    public override void Activate(AbilityManager ability)
    {
        Debug.Log("JOY: Currently Joyful!");
        ability.color = color;
    }


    public override void SubscribedEvent(AbilityManager ability, CrowdlingBrain crowdling)
    {
        crowdling.ChangeColor(ability.color);
        crowdling.currentMood = CrowdlingBrain.mood.joyful;
        ability.StartCoroutine(Delay(crowdling));
    }

    public override void UpdateAbility(AbilityManager ability)
    {
        if (ability.input._switch)
        {
            ability.ChangeAbility(ability.neutralAbility);
        }
    }

    private IEnumerator Delay(CrowdlingBrain crowdling)
    {
        Debug.Log("Firing...");
        yield return new WaitForSeconds(1);
        crowdling.SwitchState(crowdling.flingState);
    }
}
