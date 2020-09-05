using Assets.Scripts.EventArgs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class CharacterGameStrategy : IGameStrategy
{
    public IActionStrategy strategyAction;

    #region SFX
    public AudioClip PunchSound { get; set; }
    public AudioClip KickSound { get; set; }
    #endregion

    #region attributes
    public string Name { get; set; }

    public float Life { get; set; } = 100f;
    public float PunchDmg { get; set; }  = 10f;
    public float KickDmg { get; set; }  = 20f;
    public float Speed { get; set; }  = 1.5f;
    public float AttackSpeed { get; set; }  = 0f;
    #endregion

    public bool IsHitting { get; set; }  = false;
    
    public event PlayerTakeDmgHandler OnPlayerTakeDmg;
    public event EventHandler OnPlayerFigherHit;
    public event EventHandler<DeathArgs> OnPlayerDeath;
    
    protected GameObject Parent;
    
    private readonly Animator animator;

    public CharacterGameStrategy(GameObject parent, IActionStrategy action, AudioClip punchSound, AudioClip kickSound)
    {
        PunchSound = punchSound;
        KickSound = kickSound;
        Parent = parent;
        strategyAction = action;
        animator = parent.GetComponent<Animator>();
    }

    private void DoDmg(float dmg)
    {
        Vector2 direction = Vector2.right;

        if(Parent.transform.localScale.x < 0)
        {
            direction = Vector2.left;
        }

        var circleCast = Physics2D.CircleCast(Parent.transform.position + new Vector3(0.245f * direction.x, 0.14f), 0.09f, direction, 0.0f);

        if (circleCast)
        {
            var fighter = circleCast.collider.gameObject.GetComponent<Fighter>();
            fighter.TakeDmg(dmg, this);

            Debug.Log($"Vidinha: {(fighter.StrategyFighter as CharacterGameStrategy).Life}\nName:{fighter.name}");
        }
    }

    public void Idle()
    {
        if (!IsHitting) animator.SetFloat("Blend", 0f);
    }

    public void Kick()
    {
        if (!IsHitting && strategyAction.ShouldKick())
        {
            Viola.Instance.Source.PlayOneShot(KickSound, volumeScale: 1);
            animator.SetFloat("Blend", 0.3315068f);
            IsHitting = true;

            DoDmg(KickDmg);

            OnPlayerFigherHit?.Invoke(this, null);
        }
    }

    public void Punch()
    {
        if (!IsHitting && strategyAction.ShouldPunch())
        { 
            Viola.Instance.Source.PlayOneShot(PunchSound, volumeScale: 1);
            animator.SetFloat("Blend", 0.6684932f);
            IsHitting = true;

            DoDmg(PunchDmg);

            OnPlayerFigherHit?.Invoke(this, null);
        }
    }

    public void Walk()
    {
        if (IsHitting) return;
        if (strategyAction.ShouldWalkLeft())
        {
            Parent.transform.position += Vector3.left * Speed * Time.deltaTime;
            animator.SetFloat("Blend", 1f);
        }
        else if (strategyAction.ShouldWalkRight())
        {
            Parent.transform.position += Vector3.right * Speed * Time.deltaTime;
            animator.SetFloat("Blend", 1f);
        }
    }

    public void TakeDmg(float dmg, IGameStrategy sender)
    {
        if (Life - dmg <= 0)
        {
            Life = 0;
            OnPlayerTakeDmg?.Invoke(Life, this);
            OnPlayerDeath?.Invoke(this, new DeathArgs(sender));
            return;
        }

        Life -= dmg;
        OnPlayerTakeDmg?.Invoke(Life, this);
    }
}
