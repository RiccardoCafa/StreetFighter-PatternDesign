using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bison : CharacterGameStrategy
{
    public Bison(GameObject go, IActionStrategy action, AudioClip punchSound, AudioClip kickSound) : base(go, action, punchSound, kickSound)
    {
        AttackSpeed = 0.02f;
        Name = "Bison";
    }
}
