using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode activationKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(activationKey)) {
            if(canBePressed)
            {
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
            }
        }

        if(transform.position.y <= -3)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;
            GameManager.instance.NoteMissed();
        }
    }
}
