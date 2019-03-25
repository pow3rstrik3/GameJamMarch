using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IState
{
    public abstract void onEntry();
    public abstract void onUpdate();
    public abstract void onFixedUpdate();
    public abstract void onExit();
}
