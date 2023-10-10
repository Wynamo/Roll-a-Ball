using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonManager : MonoBehaviour
{
    public GameObject playButton;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("newGame"))
        {
            playButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(false);
        }
    }

}
