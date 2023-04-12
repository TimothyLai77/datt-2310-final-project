using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJump2 : MonoBehaviour
{
    private Rigidbody2D rb;
    [Range(1, 20)]
    public float jumpVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
    }
}
