using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AngerAbility : AbilityBase
{
    private Color color;
   
    public override void Activate(AbilityManager ability)
    {
        Debug.Log("ANGRY: Currently Angry!!!");
        ability.color = Color.red;
        color = ability.color;

        
    }

    public override void SubscribedEvent(AbilityManager ability, CrowdlingBrain crowdling)
    {
        crowdling.ChangeColor(color);
        crowdling.currentMood = CrowdlingBrain.mood.angry;
        ability.StartCoroutine(Delay(crowdling));
    }

    public override void UpdateAbility(AbilityManager ability)
    {
        if (ability.input._switch)
        {
            ability.ChangeAbility(ability.joyAbility);
        }
    }


    private IEnumerator Delay(CrowdlingBrain crowdling)
    {
        Debug.Log("Firing...");
        yield return new WaitForSeconds(1);
        crowdling.SwitchState(crowdling.flingState);
    }

    

}
