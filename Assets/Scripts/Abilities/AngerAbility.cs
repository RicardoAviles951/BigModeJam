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
        ability.visManager.noiseFrequency   = 4f;
        ability.visManager.noiseStrength    = 4f;
        ability.visManager.noiseScrollSpeed = 0;

        
    }

    public override void SubscribedEvent(AbilityManager ability, CrowdlingBrain crowdling)
    {
        crowdling.ChangeColor(color);
        crowdling.MoodSound(crowdling.angrySound);
        crowdling.currentMood = CrowdlingBrain.mood.angry;
        ability.StartCoroutine(Delay(crowdling));
    }

    public override void UpdateAbility(AbilityManager ability)
    {
        if (ability.input._switch)
        {
            ResetNoise(ability);
            ability.ChangeAbility(ability.joyAbility);
        }
    }


    private IEnumerator Delay(CrowdlingBrain crowdling)
    {
        Debug.Log("Firing...");
        yield return new WaitForSeconds(1);
        crowdling.SwitchState(crowdling.flingState);
    }

    private void ResetNoise(AbilityManager ability)
    {
        ability.visManager.noiseFrequency   = 0;
        ability.visManager.noiseStrength    = 0;
        ability.visManager.noiseScrollSpeed = 0;
    }

}
