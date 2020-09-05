using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard2ActionStrategy : IActionStrategy
{
    public bool ShouldKick()
    {
        return Input.GetKeyDown(KeyCode.RightControl);
    }

    public bool ShouldPunch()
    {
        return Input.GetKeyDown(KeyCode.RightShift);
    }

    public bool ShouldWalkLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    public bool ShouldWalkRight()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }
}
