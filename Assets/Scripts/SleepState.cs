using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepState : IState
{
    public void OnEnter(StateController sc)
    {
        // "What was that!?"
    }
    public void UpdateState(StateController sc)
    {
        // Search for player
    }
    public void OnHurt(StateController sc)
    {
        // Transition to Hurt State
    }
    public void OnExit(StateController sc)
    {
        // "Must've been the wind"
    }
}
