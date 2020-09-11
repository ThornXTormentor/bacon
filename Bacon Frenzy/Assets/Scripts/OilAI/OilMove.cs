using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilMove : OilState
{
    float oilDuration;
    Vector3 targetSize = new Vector3 (0,0,0);
    float shrinkSpeed = 1f;
    float shrinkDuration = 5;
    GameObject oil;

    public OilMove(OilStateController stateController) : base(stateController)
    {

    }
    public override void CheckTransitions()
    {
        //After random pos is located : start timer : when timer ends : switch to OilStop state
        if (shrinkDuration <= 0.0f)
        {
            stateController.SetState(new OilStop(stateController));
        }
    }

    public override void Act()
    {
        //Shrink in size : get area of play area and random a position : Then either switch to OilStop state or
        //wait x seconds (could be incremented with duration of game increasing difficulty) : Then switch
        shrinkDuration -= Time.deltaTime;
      
        oil.transform.localScale = Vector3.Lerp(oil.transform.localScale, targetSize, shrinkSpeed * Time.deltaTime);

        

    }
    public override void OnStateEnter()
    {

        oil = stateController.thisObj;
    }
}
