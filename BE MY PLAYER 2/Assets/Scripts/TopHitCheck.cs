using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHitCheck : MonoBehaviour
{
    public bool falling;
    public bool reset;
    public bool fallingSound;
    private Vector3 movingDown;
    private Vector3 movingUp;   
    public float dropSpeed;
    public float upSpeed;
    private Vector3 oriPos;
    public SoundFX sound;
    // Start is called before the first frame update
    void Start()
    {
        oriPos = transform.position;
        falling = false;
        movingDown = new Vector3(0, -dropSpeed*Time.deltaTime, 0);
        movingUp = new Vector3(0, upSpeed*Time.deltaTime, 0);
        reset = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (falling && !reset)
        {
            transform.position += movingDown;
            if (fallingSound == false)
            {
                sound.FallingSpikeSound();
            }
            fallingSound = true;
            
        }
        if (transform.position.y > oriPos.y)
        {
            falling = false;
            reset = false;
        }
        if (!falling && reset)
        {
            transform.position += movingUp;
            if (fallingSound == true)
            {
                sound.Stop();
                sound.SpikeBoomSound();
                
            }
            fallingSound = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { 
            if (!falling && !reset)
            {
                falling = true;
                Debug.Log("start Falling"); // test
            }
        }
    }

    public void startReset()
    {
        falling = false;
        reset = true;
    }
    
}
