using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartup : MonoBehaviour
{

    public static bool firstCall = true;

    private void Awake()
    {
        if (firstCall)
        {
            PlayerPrefs.DeleteKey("level1complete");
            PlayerPrefs.DeleteKey("level2complete");
        }
        firstCall = false;
    }

}
