using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaconPatrolState : BaconState
{
    Transform destination;

    public BaconPatrolState(BaconStateController baconStateController) : base(baconStateController)
    {

    }
    public override void CheckTransitions()
    {
        if (baconStateController.CheckIfInRange("Player"))
        {
            baconStateController.SetState(new BaconFleeState(baconStateController));
        }
    }
    public override void Act()
    {
        if (destination == null || baconStateController.ai.DestinationReached())
        {
            destination = baconStateController.GetNextNavPoint();
            baconStateController.ai.SetTarget(destination);
        }
    }

    public override void OnStateEnter()
    {
        destination = baconStateController.GetNextNavPoint();
        if (baconStateController.ai.agent != null)
        {
            baconStateController.ai.agent.speed = 0.7f;
        }
        baconStateController.ai.SetTarget(destination);
        baconStateController.ChangeColor(Color.blue);
    }
}
