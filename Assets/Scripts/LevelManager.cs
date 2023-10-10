using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }

    public void NewGame(string sceneName)
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("newGame", "true");
        SceneManager.LoadScene(sceneName);
    }
}
