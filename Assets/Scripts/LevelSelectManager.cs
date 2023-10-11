using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public GameObject levelSelectManager;

    public void EnterLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
