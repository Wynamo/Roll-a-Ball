using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{

    private Vector3 initialPosition;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject gameOverTextObject;
    public TextMeshProUGUI livesText;
    public GameObject restartButton;

    private int currentLives;
    public int startingLives = 3;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        count = 0;
        currentLives = startingLives;
        SetCountText();
        SetLivesText();
        winTextObject.SetActive(false);
        gameOverTextObject.SetActive(false);
        restartButton.SetActive(false);
        rb.isKinematic = false;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 MovementVector = movementValue.Get<Vector2>();
        movementX = MovementVector.x;
        movementY = MovementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >=11)
        {
            winTextObject.SetActive(true);
        }
    }

    void OnDeath()
    {
        currentLives--;
        SetLivesText();
        transform.position = initialPosition;
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + currentLives.ToString();
        if(currentLives <= 0)
        {
            gameOverTextObject.SetActive(true);
            restartButton.SetActive(true);
            rb.isKinematic = true;
        }
    }

     void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
       
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            OnDeath();
        }
    }

}
