using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyAbility : AbilityBase
{
    public override void Activate(AbilityManager ability)
    {
        Debug.Log("Currently Joyful!");
    }

    public override void UpdateAbility(AbilityManager ability)
    {
        
    }
}
