using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurntStateController : MonoBehaviour
{
    public BurntState currentState;
    public GameObject[] navPoints;
    public int navPointNum;
    public float remainingDistance;
    public Transform destination;
    public Renderer[] childrenRend;
    public GameObject[] enemies;
    public float detectionRange = 5;
    public GameObject enemyToChase;
    public AIPlayer ai;

    public Transform GetNextNavPoint()
    {
        navPointNum = (navPointNum + 1) % navPoints.Length; //iterates through all of them. if length = 3 and you're on 4, it will be navpoint 1. very efficient.
        return navPoints[navPointNum].transform; //gets the position of the nav point
    }

    public void ChangeColor(Color color)
    {
        foreach (Renderer r in childrenRend)
        {
            foreach (Material m in r.materials)
            {
                m.color = color;
            }
        }
    }

    public bool CheckIfInRange(string tag)
    {
        enemies = GameObject.FindGameObjectsWithTag(tag);
        if (enemies != null)
        {
            foreach (GameObject g in enemies)
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
        ai = GetComponent<AIPlayer>();
        childrenRend = GetComponentsInChildren<Renderer>();
        SetState(new BurntPatrolState(this));
        //TODO: set the initial state
    }

    // Update is called once per frame
    void Update()
    {
        currentState.CheckTransitions();
        currentState.Act();
    }
    public void SetState(BurntState burntState)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = burntState;
        gameObject.name = "AI agent in state" + burntState.GetType().Name;
        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }
}

