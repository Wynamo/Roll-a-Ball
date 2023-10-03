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

    public PlayerController player;

    public TextAsset textFile;
    public string[] textLines;
    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);
        player = FindObjectOfType<PlayerController>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

    }

    private void Update()
    {
        theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            currentLine += 1;
        }

        if (currentLine > endAtLine)
        {
            textBox.SetActive(false);
        }
    }
}
