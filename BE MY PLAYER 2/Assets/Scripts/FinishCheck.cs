using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCheck : MonoBehaviour
{

    public GameObject player;
    public bool levelFinished;
    // Start is called before the first frame update
    void Start()
    {
        levelFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // tell timer to stop
            levelFinished = true;
        }
    }
}
