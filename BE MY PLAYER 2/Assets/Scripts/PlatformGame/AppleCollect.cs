using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollect : MonoBehaviour
{
    public SoundFX soundfx;
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
            soundfx.AppleSound();
            gameObject.SetActive(false);
            Timer.instance.AppleCollect();
        }
    }
}
