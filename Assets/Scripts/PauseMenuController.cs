using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{

    public GameObject pauseMenu;

    public TextBoxManager textBoxManager;

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
        if (textBoxManager.isActive && Input.GetKeyDown(KeyCode.Escape))
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !isActive)
        {
            isActive = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isActive)
        {
            isActive = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Resume()
    {
        isActive = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
