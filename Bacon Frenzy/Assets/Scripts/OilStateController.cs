using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilStateController : MonoBehaviour
{
    //Every x seconds, get new location in area of pan. enter into move state. once new location reached, enter into
    //stay/grow state. Constantly check if entitys are colliding, if so call function that stops their movement.
    //Get a reference to that enemy, call function that changes its state to stop for x seconds. All other entities
    //will need a stop state.


    public State currentState;
   // public GameObject[] navPoints;
   // public int navPointNum;
   // public float remainingDistance;
   // public Transform destination;
    public GameObject[] entitys;
    public float detectionRange = 5;
    public GameObject enemyToChase;

    public Transform GetNextNavPoint()
    {
        navPointNum = (navPointNum + 1) % navPoints.Length; //iterates through all of them. if length = 3 and you're on 4, it will be navpoint 1. very efficient.
        return navPoints[navPointNum].transform; //gets the position of the nav point
    }

    

    public bool CheckIfInRange(string tag)
    {
        entitys = GameObject.FindGameObjectsWithTag(tag);
        if (entitys != null)
        {
            foreach (GameObject g in entitys)
            {
                if (Vector3.Distance(g.transform.position, transform.position) < detectionRange)
                {
                    enemyToChase = g;
                    return true;
                }
            }
        }
        return false;
    }

    void Start()
    {
        navPoints = GameObject.FindGameObjectsWithTag("navpoint");
        ai = GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>();
        childrenRend = GetComponentsInChildren<Renderer>();
        SetState(new PatrolState(this));
        //TODO: set the initial state
    }

    // Update is called once per frame
    void Update()
    {
        currentState.CheckTransitions();
        currentState.Act();
    }
    public void SetState(State state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        gameObject.name = "AI agent in state" + state.GetType().Name;
        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }
}
