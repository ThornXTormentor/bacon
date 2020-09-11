using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurntChaseState : BurntState
{
    Transform destination;
    public BurntChaseState(BurntStateController burntStateController) : base(burntStateController)
    {

    }
    public override void CheckTransitions()
    {
        if (!burntStateController.CheckIfInRange("Player"))
        {
            burntStateController.SetState(new BurntPatrolState(burntStateController));
        }
    }
    public override void Act()
    {
        if (burntStateController.enemyToChase != null)
        {
            destination = burntStateController.enemyToChase.transform;
            burntStateController.ai.SetTarget(destination);
        }
    }
    public override void OnStateEnter()
    {
        burntStateController.ChangeColor(Color.red);
        //set the ai's speed 
    }
}
