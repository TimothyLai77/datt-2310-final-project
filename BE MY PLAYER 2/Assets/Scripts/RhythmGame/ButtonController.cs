using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public SoundFX sound;

    [SerializeField] private Sprite defaultImage;
    [SerializeField] private Sprite pressedImage;

    [SerializeField] private KeyCode activationKey;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(activationKey))
        {
            spriteRenderer.sprite = pressedImage;
            sound.ArrowSound();
        }
        
        if (Input.GetKeyUp(activationKey)) {
            spriteRenderer.sprite = defaultImage;
        }
    }
}
