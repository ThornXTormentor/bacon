using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    Transform destination;
    public ChaseState(StateController stateController): base(stateController)
    {

    }
    public override void CheckTransitions()
    {
        if (!stateController.CheckIfInRange("Player"))
        {
            stateController.SetState(new PatrolState(stateController));
        }
    }
    public override void Act()
    {
        if(stateController.enemyToChase != null)
        {
            destination = stateController.enemyToChase.transform;
            //set the ai's target to be the player.
        }
    }
    public override void OnStateEnter()
    {
        stateController.ChangeColor(Color.red);
        //set the ai's speed 
    }
}
