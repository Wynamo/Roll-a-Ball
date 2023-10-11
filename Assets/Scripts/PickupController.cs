using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupController : MonoBehaviour
{
    private int numberOfPickups;

    public string levelName;

    public string levelNameCompletedKey;

    public GameObject continueButton;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private int count;
    // Start is called before the first frame update
    void Start()
    {
        numberOfPickups = CountPickups();
        Time.timeScale = 1f;
        SetCountText();
        count = 0;
        winTextObject.SetActive(false);
        continueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 1)
        {
            winTextObject.SetActive(true);
            continueButton.SetActive(true);
            Time.timeScale = 0f;
            SetBool(levelNameCompletedKey, true);
            PlayerPrefs.SetString("lastLevelCompleted", levelName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

    }

    private void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public int CountPickups()
    {
        return GameObject.FindGameObjectsWithTag("PickUp").Count();
    }
}
