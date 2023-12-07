using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MainMenuTimeline : MonoBehaviour
{

    public PlayableDirector mainMenuTimeLine;

    public void Start()
    {
        Debug.Log("hello");
        mainMenuTimeLine.Play();
        
        mainMenuTimeLine.Evaluate();
    }

    private void Update()
    {
        //Start();
    }
}
