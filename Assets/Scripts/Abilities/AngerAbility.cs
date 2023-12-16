using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AngerAbility : AbilityBase
{
    private Color color;
    private string name;
   
    public override void Activate(AbilityManager ability)
    {
        ability.moodName = "RAGE";

        Debug.Log("Mood : " + ability.moodName);
        ability.color = Color.red;
        
        name = ability.moodName;
        color = ability.color;
        //ability.moodRelay.ChangeText(name, color);
        ability.ChangeName(name,color, ability.rageFont);
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
        if (ability.input.next)
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
