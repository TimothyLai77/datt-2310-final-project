using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHitDS : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject player;
    private TopHitCheck topHitCheck;
    public SoundFX soundfx;
    // Start is called before the first frame update
    void Start()
    {
        topHitCheck = GetComponentInParent<TopHitCheck>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if player collides with death object they respawn at start
        if (collision.gameObject.CompareTag("Player"))
        {
            soundfx.DeathSound();
            player.transform.position = startPoint.transform.position;
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            topHitCheck.startReset();
            Debug.Log("start reset");//test
        }
    }
}
