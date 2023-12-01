using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralAbility : AbilityBase
{
    public override void Activate(AbilityManager ability)
    {
        Debug.Log("Not feeling anything.");
    }

    public override void UpdateAbility(AbilityManager ability)
    {
        
    }
}
