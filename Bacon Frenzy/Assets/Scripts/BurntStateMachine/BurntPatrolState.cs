using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurntPatrolState : BurntState
{
    Transform destination;

    public BurntPatrolState(BurntStateController burntStateController) : base(burntStateController)
    {

    }
    public override void CheckTransitions()
    {
        if (burntStateController.CheckIfInRange("Player"))
        {
            burntStateController.SetState(new BurntChaseState(burntStateController));
        }
    }
    public override void Act()
    {
        if (destination == null || burntStateController.ai.DestinationReached())
        {
            destination = burntStateController.GetNextNavPoint();
            burntStateController.ai.SetTarget(destination);
        }
    }

    public override void OnStateEnter()
    {
        destination = burntStateController.GetNextNavPoint();
        if (burntStateController.ai.agent != null)
        {
            burntStateController.ai.agent.speed = 0.7f;
        }
        burntStateController.ai.SetTarget(destination);
        burntStateController.ChangeColor(Color.blue);
    }
}
