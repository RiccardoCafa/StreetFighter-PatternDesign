using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardActionStrategy : IActionStrategy
{

    public bool ShouldKick()
    {
        return Input.GetKeyDown(KeyCode.X);
    }

    public bool ShouldPunch()
    {
        return Input.GetKeyDown(KeyCode.C);
    }

    public bool ShouldWalkLeft()
    {
        return Input.GetKey(KeyCode.A);
    }

    public bool ShouldWalkRight()
    {
        return Input.GetKey(KeyCode.D);
    }
}
