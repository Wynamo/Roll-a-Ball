using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public float timeBeforeSleep;
    public float maxTimeSleep;
    public SleepState sleepState;
    public bool canSeePlayer;
    public ChaseState chaseState;
    public GameObject player;
    public float chaseRange;

    public override State RunCurrentState()
    {
        if (timeBeforeSleep < 0)
        {
            return sleepState;
        }
        if (canSeePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    private void Update()
    {
        if (!canSeePlayer)
        {
            timeBeforeSleep -= Time.deltaTime;
        }
        else
        {
            timeBeforeSleep = maxTimeSleep;
        }

        if (Vector3.Distance(transform.position, player.transform.position) < chaseRange)
        {
            canSeePlayer = true;
        }
        else
        {
            canSeePlayer = false;
        }
    }
    //float timeBeforeSleep;
    //public void OnEnter(StateController sc)
    //{
    //    timeBeforeSleep = 20;
    //}
    //public void UpdateState(StateController sc)
    //{
    //    if (Physics.Raycast(sc.transform.position, sc.transform.forward))
    //    {
    //        sc.ChangeState(sc.chaseState);
    //    }
    //    if (timeBeforeSleep < 0)
    //    {
    //    }
    //    timeBeforeSleep -= Time.deltaTime;
    //}
    //public void OnExit(StateController sc)
    //{
    //}
}