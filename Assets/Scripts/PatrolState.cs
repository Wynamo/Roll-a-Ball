using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    float timeBeforeSleep;
    public void OnEnter(StateController sc)
    {
        timeBeforeSleep = 20;
    }
    public void UpdateState(StateController sc)
    {
        if (Physics.Raycast(sc.transform.position, sc.transform.forward))
        {
            sc.ChangeState(sc.chaseState);
        }
        if (timeBeforeSleep < 0)
        {
            sc.ChangeState(sc.sleepState);
        }
        timeBeforeSleep -= Time.deltaTime;
    }
    public void OnHurt(StateController sc)
    {
        sc.ChangeState(sc.hurtState);
    }
    public void OnExit(StateController sc)
    {
    }
}