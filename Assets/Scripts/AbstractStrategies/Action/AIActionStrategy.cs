using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionStrategy : IActionStrategy
{
    protected GameObject EnemyRef;
    protected GameObject FighterRef;
    private int NextHitType = -1;

    public void SetFighters(GameObject fighter, GameObject enemy)
    {
        FighterRef = fighter;
        EnemyRef = enemy;
    }

    public bool ShouldKick()
    {
        if (NextHitType == 0)
        {
            NextHitType = -1;
            return true;
        }

        return false;
    }

    public bool ShouldPunch()
    {
        if(NextHitType == 1)
        {
            NextHitType = -1;
            return true;
        }

        return false;
    }

    public bool ShouldWalkLeft()
    {
        if (EnemyRef == null) return false;

        float magnitude = (EnemyRef.transform.position - FighterRef.transform.position).magnitude;

        CalculateNextHit();

        if (magnitude >= 0.3f)
        {
            return true;
        }
        
        return false;
    }

    public bool ShouldWalkRight()
    {
        if (EnemyRef == null) return false;

        float magnitude = (EnemyRef.transform.position - FighterRef.transform.position).magnitude;
        
        if (magnitude < 0.1f)
        {
            return true;
        }
        
        return false;
    }

    public void CalculateNextHit()
    {
        if (Time.frameCount % 35 != 0) return;

        if (NextHitType < 0)
            NextHitType = Random.Range(-1, 2);
    }
}
