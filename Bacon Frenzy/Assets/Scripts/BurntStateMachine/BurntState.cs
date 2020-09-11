using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BurntState
{
    protected BurntStateController burntStateController;

    public abstract void CheckTransitions();
    public abstract void Act();
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
    public BurntState(BurntStateController burntStateController)
    {
        this.burntStateController = burntStateController;
    }
}
