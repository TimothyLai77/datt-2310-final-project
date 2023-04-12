using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float customG;

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

    [Range (-1f, 1f)]
    private float waitTimeVP;

    //private bool firstEnterVP;

    public GameObject manager;
    public SoundFX soundfx;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("VerticalPlatform"))
        {
            isJumping = false;
        }
        /*if (collision.gameObject.CompareTag("Untagged"))
        {
            Move = 0;
        }*/
        /*if (collision.gameObject.CompareTag("VerticalPlatform") && firstEnterVP)
        {
            isJumping = true;
            firstEnterVP = false;
            waitTimeVP = 0.5f;
            //Invoke("VPJumping", 0.5f);
            Debug.Log("locked");//test
        } else if (collision.gameObject.CompareTag("VerticalPlatform") && !firstEnterVP)
        {
            isJumping=false;
            
        }*/
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("VerticalPlatform") )
        {
            isJumping = true;
            //if (waitTimeVP <= 0f) { 

            //}
            //Invoke("VPJumping", 0.5f);
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
            isJumping = true;
            rb.velocity = Vector2.up * jumpVelocity;
            soundfx.JumpSound();
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * customG * (fallMultiplier - 1) * Time.deltaTime;
            isFalling = false;//debug
            //Debug.Log("fall");
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * customG * (lowJumpMultiplier - 1) * Time.deltaTime;
            isFalling = true;//debug
            //Debug.Log("low");
        } 

        waitTimeVP -= Time.deltaTime;
    }

    /*private void VPJumping()
    {
        if(waitTimeVP <= 0)
        {
            firstEnterVP = true;
        }
        
        //Debug.Log("unlocked");//test
    }*/

    public void speedReset()
    {
        speed = 7;
        manager.GetComponent<Timer>().speedLevel = 0;
    }


}
