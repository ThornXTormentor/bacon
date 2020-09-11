using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OilState
{
    protected OilStateController stateController;

    public abstract void CheckTransitions();
    public abstract void Act();
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
    public OilState(OilStateController stateController)
    {
        this.stateController = stateController;
    }
}
