using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public IGameStrategy StrategyFighter;

    void Start()
    {
        StrategyFighter.OnPlayerFigherHit += (sender, args) =>
        {
            if (StrategyFighter.IsHitting)
                StartCoroutine(WaitForHit());
        }; 
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + new Vector3(0.245f, 0.14f), 0.09f);
    }

    protected IEnumerator WaitForHit()
    {
        var cooldown = Mathf.Abs(StrategyFighter.AttackSpeed * 0.5f - 0.5f);

        yield return new WaitForSeconds(cooldown);
        StrategyFighter.IsHitting = false;
    }

    void Update()
    {
        Idle();
        Walk();
        Punch();
        Kick();
    }

    void Idle() => StrategyFighter.Idle();

    void Walk() => StrategyFighter.Walk();

    void Punch() => StrategyFighter.Punch();
    
    void Kick() => StrategyFighter.Kick();

    public void TakeDmg(float dmg, IGameStrategy sender) => StrategyFighter.TakeDmg(dmg, sender); 
}
