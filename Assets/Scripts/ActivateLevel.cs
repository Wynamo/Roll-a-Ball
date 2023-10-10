using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateLevel : MonoBehaviour
{
    public GameObject nextLevel;

    private bool waitForPress;

    public string sceneName;

    public GameObject levelBeaten;
    public GameObject levelNotBeaten;

    public bool isBeaten;

    public string playerPrefLevelName;

    public LevelSelectManager theLevelSelector;
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.DeleteKey("level1complete");
        isBeaten = GetBool(playerPrefLevelName);
        theLevelSelector = FindObjectOfType<LevelSelectManager>();

        if (isBeaten)
        {
            EnableLevelComplete();
            ActivateNextLevel();
        }
        else
        {
            LevelUncomplete();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForPress && Input.GetKeyDown(KeyCode.E))
        {
            theLevelSelector.EnterLevel(sceneName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        waitForPress = true;
        return;
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.name == "Player")
        {
            waitForPress = false;
        }
    }

    public void EnableLevelComplete()
    {
        levelBeaten.SetActive(true);
        levelNotBeaten.SetActive(false);
    }

    public void LevelUncomplete()
    {
        levelBeaten.SetActive(false);
        levelNotBeaten.SetActive(true);
    }

    private bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1;
    }

    public void ActivateNextLevel()
    {
        nextLevel.SetActive(true);
    }
}
