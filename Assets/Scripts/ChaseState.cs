using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{

    public float chaseDistance;
    public PatrolState patrolState;
    public bool isInChaseRange;
    public NavMeshAgent navMeshAgent;
    public GameObject player;  

    public override State RunCurrentState()
    {
        if (!isInChaseRange)
        {
            return patrolState;
        }
        else
        {
            navMeshAgent.SetDestination(player.transform.position);
            return this;
        }
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < chaseDistance)
        {
            isInChaseRange = true;
        }
        else
        {
            isInChaseRange = false;
        }
    }
}
