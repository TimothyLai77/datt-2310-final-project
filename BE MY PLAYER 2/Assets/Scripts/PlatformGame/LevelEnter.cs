using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelEnter : MonoBehaviour
{
    public bool inLevel;
    public GameObject player;
    public GameObject start;
    public GameObject manager;
    public GameObject collections;
    public int levelNum;
    private SpriteRenderer spriteRenderer;
    public SoundFX soundfx;

    private void Start()
    {
        inLevel = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        spriteRenderer.color = new Color(253 / 255f, 183 / 255f, 183 / 255f, 255 / 255f);//slightly red

        if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
        {
            soundfx.ArrowSound();
            manager.GetComponent<Timer>().countingTime = true;
            manager.GetComponent<Timer>().currentTime = 0;
            manager.GetComponent<Timer>().scorePanelB = false;
            manager.GetComponent<Timer>().finished = false;

            //reset all collections
            for (int i = 0; i < collections.transform.childCount; i++)
            {
                Transform child = collections.transform.GetChild(i);
                child.gameObject.SetActive(true);
            }

            //Enter different levels
            if (levelNum == 1)
            {
                //Enter Level 1
                player.transform.position = new Vector3(-6.37f, -3.1f, 0);
                start.transform.position = new Vector3(-6.37f, -3.1f, 0);
                manager.GetComponent<Timer>().levelNum = 1;
            }
            else if (levelNum == 2)
            {
                //Enter Level 2
                player.transform.position = new Vector3(182.66f, -3.1f, 0);
                start.transform.position = new Vector3(182.66f, -3.1f, 0);
                manager.GetComponent<Timer>().levelNum = 2;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        spriteRenderer.color = Color.white;

    }

}
