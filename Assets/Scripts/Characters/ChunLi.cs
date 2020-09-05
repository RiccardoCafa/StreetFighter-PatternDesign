using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunLi : CharacterGameStrategy
{
    public ChunLi(GameObject go, IActionStrategy action, AudioClip punchSound, AudioClip kickSound) : base(go, action, punchSound, kickSound) {
        AttackSpeed = 0.2f;
        PunchDmg = 5f;
        KickDmg = 14f;
        Name = "Chun-Li";
    }
}
