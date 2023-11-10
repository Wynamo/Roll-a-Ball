using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;

    public TextMeshProUGUI theText;

    public int currentLine;
    public int endAtLine;

    public GameObject winTextObject;
    public GameObject continueButton;

    public PlayerController player;
    public PickupController pickupController;

    public Rigidbody rb;

    public TextAsset textFile;
    public string[] textLines;

    public bool isActive;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;

    public bool stopPlayerMovement;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }

    }

    private void Update()
    {
        if (player.canMove == false)
        {
            rb.isKinematic = true;
        }
        else if (player.canMove == true)
        {
            rb.isKinematic = false;
        }

        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            if (!isTyping)
            {
                currentLine += 1;

                if (currentLine > endAtLine)
                {
                    if (pickupController.winOnTalk && PlayerPrefs.GetInt(pickupController.levelName) >= pickupController.numberOfPickups)
                    {
                        pickupController.SetBool(pickupController.levelNameCompletedKey, true);
                        PlayerPrefs.SetString("lastLevelCompleted", pickupController.levelName);
                        DisableTextBox();
                        winTextObject.SetActive(true);
                        continueButton.SetActive(true);
                        Time.timeScale = 0f;
                    }
                    else
                    {
                        DisableTextBox();
                    }
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pickupController.winOnTalk && PlayerPrefs.GetInt(pickupController.levelName) >= pickupController.numberOfPickups)
        {
            pickupController.SetBool(pickupController.levelNameCompletedKey, true);
            PlayerPrefs.SetString("lastLevelCompleted", pickupController.levelName);
            DisableTextBox();
            winTextObject.SetActive(true);
            continueButton.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            DisableTextBox();
        }
    }

    private IEnumerator TextScroll (string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter++;
            yield return new WaitForSeconds(typeSpeed);
        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

        if (stopPlayerMovement)
        {
            player.canMove = false;
        }

        StartCoroutine(TextScroll(textLines[currentLine]));
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        player.canMove = true;
    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}

//this text box manager is made by following the tutorial by gamesplusjames on youtube https://www.youtube.com/watch?v=ehmBIP5sj0M