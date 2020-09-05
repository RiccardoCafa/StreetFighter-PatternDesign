using Assets.Scripts.EventArgs;
using System;
using UnityEngine;

public delegate void PlayerTakeDmgHandler(float Life, IGameStrategy sender);

public interface IGameStrategy
{
    AudioClip PunchSound { get; set; }
    AudioClip KickSound { get; set; }

    string Name { get; set; }

    float Life { get; set; } 
    float PunchDmg { get; set; }
    float KickDmg { get; set; }
    float Speed { get; set; }
    float AttackSpeed { get; set; }

    bool IsHitting { get; set; }

    event EventHandler OnPlayerFigherHit;
    event PlayerTakeDmgHandler OnPlayerTakeDmg;
    event EventHandler<DeathArgs> OnPlayerDeath;

    void Idle();
    void Walk();
    void Punch();
    void Kick();
    void TakeDmg(float dmg, IGameStrategy sender);
}
