using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Lives : MonoBehaviour
{

    private int currentLives;
    //public int startingLives = 3;

    private Vector3 initialPosition;

    public GameObject restartButton;

    public GameObject quitButton;

    public GameObject gameOverTextObject;
    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        quitButton.SetActive(false);
        gameOverTextObject.SetActive(false);
        currentLives = PlayerPrefs.GetInt("lives");
        SetLivesText();
        initialPosition = transform.position;
        restartButton.SetActive(false);
    }

    void OnDeath()
    {
        currentLives--;
        SetLivesText();
        transform.position = initialPosition;
    }

    private void Update()
    {
        PlayerPrefs.SetInt("lives", currentLives);
    }

    void SetLivesText()
    {
        livesText.text = "x " + currentLives.ToString();
        if (currentLives <= 0)
        {
            gameOverTextObject.SetActive(true);
            restartButton.SetActive(true);
            quitButton.SetActive(true);
            PlayerPrefs.SetInt("lives", 3);
            currentLives = PlayerPrefs.GetInt("lives");
            Time.timeScale = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            OnDeath();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            OnDeath();
        }
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            collision.gameObject.SetActive(false);
            collision.gameObject.transform.parent.gameObject.SetActive(false);
        }
     }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OneUp"))
        {
            other.gameObject.SetActive(false);
            currentLives++;
            SetLivesText();
        }

    }
}
