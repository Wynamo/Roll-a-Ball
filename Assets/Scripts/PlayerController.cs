using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float maxSpeed = 15;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
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
        if(count >=9)
        {
            winTextObject.SetActive(true);
        }
    }

    

     void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
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

    private void Update()
    {
        if (!canMove)
        {
            return;
        }
    }

}
