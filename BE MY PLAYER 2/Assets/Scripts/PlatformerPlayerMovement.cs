using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Range(1, 10)]
    public float speed;
    private float Move;

    [Range(1, 20)]
    public float jumpVelocity;


    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;
    public KeyCode jump;
    public bool isJumping;
    public bool isFalling; //debug
    public SoundFX sound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        /*if (collision.gameObject.CompareTag("Untagged"))
        {
            Move = 0;
        }*/
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal move part
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
        //Debug.Log(rb.velocity);



        //jump part
        if (Input.GetButton("Jump") && !isJumping)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            isJumping = true;
            sound.JumpSound();
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            isFalling = false;//debug
            //Debug.Log("fall");
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            isFalling = true;//debug
            //Debug.Log("low");
        } 
    }

    
}
