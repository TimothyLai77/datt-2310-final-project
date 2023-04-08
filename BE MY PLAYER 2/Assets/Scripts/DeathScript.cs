using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if player collides with death object they respawn at start
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = startPoint.transform.position;
            player.GetComponent<PlatformerPlayerMovement>().speedReset();
        }
    }
}
