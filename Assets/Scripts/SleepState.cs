using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepState : State
{

    public bool wokenUp;
    public GameObject player;
    public float awakenDistance;
    public ChaseState chaseState;

    public override State RunCurrentState()
    {
        if (wokenUp)
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
        if (Vector3.Distance(transform.position, player.transform.position) < awakenDistance)
        {
            wokenUp = true;
        }
        else
        {
            wokenUp = false;
        }
    }
}
