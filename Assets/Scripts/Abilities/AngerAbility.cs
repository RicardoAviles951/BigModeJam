using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerAbility : AbilityBase
{
    public override void Activate(AbilityManager ability)
    {
        Debug.Log("Currently Angry!!!");
    }

    public override void UpdateAbility(AbilityManager ability)
    {
        
    }
}
