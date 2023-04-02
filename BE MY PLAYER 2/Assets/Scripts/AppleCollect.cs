using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            gameObject.SetActive(false);
            Timer.instance.AppleCollect();
        }
    }
}
