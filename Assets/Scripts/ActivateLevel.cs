using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateLevel : MonoBehaviour
{
    public GameObject nextLevel;
    public GameObject nextLevelPath;

    private bool waitForPress;

    public string sceneName;

    public GameObject player;

    public GameObject levelBeaten;
    public GameObject levelNotBeaten;

    public bool isBeaten;

    public string levelLastCompleted;

    public string playerPrefLevelName;

    public LevelSelectManager theLevelSelector;
    // Start is called before the first frame update
    void Start()
    {
        levelLastCompleted = PlayerPrefs.GetString("lastLevelCompleted");
        isBeaten = GetBool(playerPrefLevelName);
        theLevelSelector = FindObjectOfType<LevelSelectManager>();

        if (levelLastCompleted == sceneName)
        {
            player.transform.position = SetPlayerPosition();
        }

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

        if (other.name == "OrboExpo2")
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
        nextLevelPath.SetActive(true);
    }

    public Vector3 SetPlayerPosition()
    {
        Vector3 playerPosition = levelBeaten.transform.position;
        playerPosition.y = 2.9f;
        return playerPosition;
    }
}
