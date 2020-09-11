using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OilStop : OilState
{
    float oilDuration;
    Vector3 targetSize = new Vector3(3, .01f, 3);
    float growSpeed = .2f;
    float growDuration = 10;
    GameObject oil;

    public OilStop(OilStateController stateController) : base(stateController)
    {

    }
    public override void CheckTransitions()
    {
        //See if timer is up, then change to OilMove state.
        if (oilDuration < 0.0f)
            stateController.SetState(new OilMove(stateController));
    }

    public override void Act()
    {
        // Grow in size
        // Once growDuration is reached => stop growing => start oilDuration timer

        growDuration -= Time.deltaTime;
        if (growDuration <= 0.0f)
        {
            oilDuration -= Time.deltaTime;
            Debug.Log(oilDuration);

        }
        else
        {
            oil.transform.localScale = Vector3.Lerp(oil.transform.localScale, targetSize, growSpeed * Time.deltaTime);
        }
    }
    public override void OnStateEnter()
    {
        // Get random num in range : use it as the num of seconds this state

        oil = stateController.thisObj;
        oilDuration = UnityEngine.Random.Range(3.0f, 7.0f);
        Debug.Log("Initial oilDuration: " + oilDuration);
    }
}
