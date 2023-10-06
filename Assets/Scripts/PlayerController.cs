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

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 MovementVector = movementValue.Get<Vector2>();
        movementX = MovementVector.x;
        movementY = MovementVector.y;
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

    private void Update()
    {
        if (!canMove)
        {
            return;
        }
    }

}
