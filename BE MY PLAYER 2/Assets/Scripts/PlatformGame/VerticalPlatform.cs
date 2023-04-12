using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effect;
    
    [Range(-1f, 1f)]
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        effect = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow)|| Input.GetKeyUp(KeyCode.S))
        {
            if(waitTime <= 0f) { 
                this.waitTime = 0.5f;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) && waitTime <= 0f)
        {
            //effect.rotationalOffset = 180f; //both method achieve same thing
            this.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("VPReset", 0.2f);
            if (waitTime <= 0f)
            {
                this.waitTime = 0.5f;
            }
        }
        else
        {
            //this.waitTime -= Time.deltaTime;
        }
        if (Input.GetButton("Jump"))
        {
            effect.rotationalOffset = 0f;
        }
        this.waitTime -= Time.deltaTime;

    }

    private void VPReset()
    {
//effect.rotationalOffset = 0f;
        this.GetComponent<BoxCollider2D>().enabled = true;
    }
}