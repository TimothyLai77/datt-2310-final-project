using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHitChildCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {/*
            TopHitCheck.instance.falling = false;
            TopHitCheck.instance.reset = true;*/
            Debug.Log("start reset");
        }
    }
}
