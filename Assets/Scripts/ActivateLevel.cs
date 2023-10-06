using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateLevel : MonoBehaviour
{

    private bool waitForPress;

    public string sceneName;

    public GameObject levelBeaten;
    public GameObject levelNotBeaten;

    public bool isBeaten;

    public LevelSelectManager theLevelSelector;
    // Start is called before the first frame update
    void Start()
    {
        theLevelSelector = FindObjectOfType<LevelSelectManager>();

        if (isBeaten)
        {
            EnableLevelComplete();
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
}
