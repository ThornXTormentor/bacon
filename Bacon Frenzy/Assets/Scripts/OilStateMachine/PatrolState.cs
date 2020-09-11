using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{

    Transform destination;

    public PatrolState(StateController stateController) : base(stateController)
    {

    }

    public override void CheckTransitions()
    {
        if (stateController.CheckIfInRange("Player"))
        {
            stateController.SetState(new ChaseState(stateController));
        }
    }
    public override void Act()
    {
        //TODO
        //if destination is null and destination not reached
        //Get next target in state controller
        //set the target to that transform.
    }

    public override void OnStateEnter()
    {
        //set the destination to the next nav point
        //if the ai this script is attached to DOES exist,
        //then set the speed
        //no matter what, set the target to a destination
        //change color for ui
        destination = stateController.GetNextNavPoint();
        stateController.ChangeColor(Color.blue);
    }
}
