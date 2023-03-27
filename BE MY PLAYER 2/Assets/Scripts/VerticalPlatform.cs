using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effect;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        effect = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.5f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            effect.rotationalOffset = 180f;
            waitTime = 0.5f;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
        if (Input.GetButton("Jump"))
        {
            effect.rotationalOffset = 0f;
        }

    }
}