using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDone : MonoBehaviour
{
    public GameObject player;
    public GameObject start;
    public GameObject manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = new Vector3(-56.75f, - 13.37f, 0f);
        start.transform.position = new Vector3(-56.75f, -13.37f, 0f);
        manager.GetComponent<Timer>().countingTime = false;
        manager.GetComponent <Timer>().scorePanelB = true;
        manager.GetComponent<Timer>().finished = true;
    }
}
