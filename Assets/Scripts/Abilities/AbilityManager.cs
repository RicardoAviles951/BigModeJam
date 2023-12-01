using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{

    AbilityBase currentAbility;
    public NeutralAbility neutralAbility = new NeutralAbility();
    public AngerAbility angerAbility     = new AngerAbility();
    public JoyAbility joyAbility         = new JoyAbility();

    public float duration;
    public float cooldown;
    public float afflictionRadius;


    // Start is called before the first frame update
    void Start()
    {
        currentAbility = neutralAbility;
        currentAbility.Activate(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentAbility.UpdateAbility(this);
    }

    public void ChangeAbility(AbilityBase ability)
    {
        currentAbility = ability;
        ability.Activate(this);
    }
}
