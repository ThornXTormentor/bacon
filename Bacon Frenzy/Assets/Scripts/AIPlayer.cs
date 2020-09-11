using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }
 


    private void Start()
    {
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();

        agent.updateRotation = false;
        agent.updatePosition = true;
    }
    private void Update()
    {
        if (target != null)
            agent.SetDestination(target.position);

        if (!DestinationReached())
        {
            Move();
        }
        else
            Stop();
    }
    public bool DestinationReached()
    {
        return agent.remainingDistance < agent.stoppingDistance;
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    public void Stop()
    {
        //stop
    }
}
