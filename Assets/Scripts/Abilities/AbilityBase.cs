using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBase
{
    public abstract void Activate(AbilityManager ability);
    public abstract void UpdateAbility(AbilityManager ability);
}
