using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuControllerWorldMap : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject controlsMenu;

    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isActive)
        {
            isActive = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isActive)
        {
            isActive = false;
            pauseMenu.SetActive(false);
            controlsMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Resume()
    {
        isActive = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Controls()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void Back()
    {
        pauseMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }
}
