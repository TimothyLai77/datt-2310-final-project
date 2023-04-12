using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject startPos;
    public bool pointChecked = false;
    public Sprite checkedSprite;
    private SpriteRenderer spriteRenderer;
    public SoundFX soundfx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("CheckpointAchieved");
            spriteRenderer.sprite = checkedSprite;
            soundfx.CheckpointFinishSound();
            if (pointChecked == false)
            {
                pointChecked = true;
                startPos.transform.position = transform.position;
            }
        }
    }

    
}
