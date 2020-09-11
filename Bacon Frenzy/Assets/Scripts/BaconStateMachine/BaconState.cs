using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaconState
{
    protected BaconStateController baconStateController;

    public abstract void CheckTransitions();
    public abstract void Act();
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
    public BaconState(BaconStateController baconStateController)
    {
        this.baconStateController = baconStateController;  
    }
}
