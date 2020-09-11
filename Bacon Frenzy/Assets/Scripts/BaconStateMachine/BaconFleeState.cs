using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaconFleeState : BaconState
{
    Transform destination;
    public BaconFleeState(BaconStateController baconStateController) : base(baconStateController)
    {

    }
    public override void CheckTransitions()
    {
        if (!baconStateController.CheckIfInRange("Player"))
        {
            baconStateController.SetState(new BaconPatrolState(baconStateController));
        }
    }
    public override void Act()
    {
        if (baconStateController.enemyToFlee != null)
        {
            destination = baconStateController.enemyToFlee.transform;
            baconStateController.ai.SetTarget(destination);  // Needs to change to where the player is + a distance.
        }
    }
    public override void OnStateEnter()
    {
        baconStateController.ChangeColor(Color.red);
        baconStateController.ai.agent.speed = 1f;
    }
}
