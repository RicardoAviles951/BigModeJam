using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyAbility : AbilityBase
{
    Color color = Color.green;
    string name;
    public override void Activate(AbilityManager ability)
    {
        ability.moodName = "JOY";
        Debug.Log("Mood: " + ability.moodName);
        ability.color = color;

        name = ability.moodName;
        //ability.moodRelay.ChangeText(name, color);
        ability.ChangeName(name, color, ability.joyFont);
        ability.visManager.noiseStrength = 2;
    }


    public override void SubscribedEvent(AbilityManager ability, CrowdlingBrain crowdling)
    {
        crowdling.ChangeColor(ability.color);
        crowdling.MoodSound(crowdling.joySound, .5f);
        crowdling.currentMood = CrowdlingBrain.mood.joyful;
        ability.StartCoroutine(Delay(crowdling));
    }

    public override void UpdateAbility(AbilityManager ability)
    {
        if (ability.input.next)
        {
            ResetNoise(ability);
            ability.ChangeAbility(ability.neutralAbility);
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
        ability.visManager.noiseFrequency = 0;
        ability.visManager.noiseStrength = 0;
        ability.visManager.noiseScrollSpeed = 0;
    }
}
