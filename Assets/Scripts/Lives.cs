using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Lives : MonoBehaviour
{

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public Sprite fullHeart;
    public Sprite threeQuarterHeart;
    public Sprite halfHeart;
    public Sprite quarterHeart;
    public Sprite emptyHeart;

    public AudioSource audioSource;
    public AudioClip[] hurtSounds;

    private int currentLives;
    //public int startingLives = 3;

    public PlayerJump playerJump;

    private Vector3 initialPosition;

    public GameObject restartButton;

    public int maxHealth;
    public int currentHealth;

    public GameObject quitButton;
    public GameObject gameOverTextObject;
    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        quitButton.SetActive(false);
        gameOverTextObject.SetActive(false);
        currentLives = PlayerPrefs.GetInt("lives");
        SetLivesText();
        InitHearts();
        initialPosition = transform.position;
        restartButton.SetActive(false);
    }

    void OnDeath()
    {
        currentLives--;
        currentHealth = maxHealth;
        transform.position = initialPosition;
        InitHearts();
        SetLivesText();
    }

    private void InitHearts()
    {
        heart1.GetComponent<Image>().sprite = fullHeart;
        heart2.GetComponent<Image>().sprite = fullHeart;
        heart3.GetComponent<Image>().sprite = fullHeart;
    }

    void OnHit(int damage)
    {
        currentHealth -= damage;
        audioSource.PlayOneShot(hurtSounds[Random.Range(0, hurtSounds.Length)]);
        switch (currentHealth)
        {
            case 0:  heart3.GetComponent<Image>().sprite = emptyHeart; OnDeath(); break;
            case 1:  heart3.GetComponent<Image>().sprite = quarterHeart; break;
            case 2:  heart3.GetComponent<Image>().sprite = halfHeart; break;
            case 3:  heart3.GetComponent<Image>().sprite = threeQuarterHeart; break;
            case 4:  heart2.GetComponent<Image>().sprite = emptyHeart; break;
            case 5:  heart2.GetComponent<Image>().sprite = quarterHeart; break;
            case 6:  heart2.GetComponent<Image>().sprite = halfHeart; break;
            case 7:  heart2.GetComponent<Image>().sprite = threeQuarterHeart; break;
            case 8:  heart1.GetComponent<Image>().sprite = emptyHeart; break;
            case 9:  heart1.GetComponent<Image>().sprite = quarterHeart; break;
            case 10: heart1.GetComponent<Image>().sprite = halfHeart; break;
            case 11: heart1.GetComponent<Image>().sprite = threeQuarterHeart; break;
            case 12: break;
        }
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
            OnHit(4);
            transform.position = playerJump.lastGroundedPosition;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            OnHit(1);
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
