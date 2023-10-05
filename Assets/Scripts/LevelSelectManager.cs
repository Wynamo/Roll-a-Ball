using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{

    private bool waitForPress;

    public string sceneName;

    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForPress && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Assert(true);
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Level1"))
        {
            waitForPress = true;
            return;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.name == "Player")
        {
            waitForPress = false;
        }
    }
}
