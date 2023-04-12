using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class ScorePanelEnter : MonoBehaviour
{
    public GameObject manager;
    private SpriteRenderer spriteRenderer;
    public SoundFX soundfx;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        spriteRenderer.color = new Color(253 / 255f, 183 / 255f, 183 / 255f, 255 / 255f);//slightly red
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            soundfx.ArrowSound();
            manager.GetComponent<Timer>().openScorePanel();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        spriteRenderer.color = Color.white;

    }
}
