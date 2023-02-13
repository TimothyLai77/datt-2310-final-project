using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;

    public Rigidbody2D rb;

    Vector2 movement;


    void Start()
    {
         
    }

   
    void Update() {
        MovementInput();
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;

    }

    void MovementInput ()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        movement = new Vector2(mx, my).normalized;
    }
}
