using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode activationKey;

    private GameObject activator;

    [SerializeField] private float perfectThreshold = 0.2f;
    [SerializeField] private float greatThreshold = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        activator = null;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(activationKey)) {
            if(canBePressed)
            {
                gameObject.SetActive(false);

                if (activator != null)
                { 

                    if (Mathf.Abs(activator.transform.position.y - transform.position.y) <= perfectThreshold)
                    {
                        Debug.Log("Perfect Hit");
                        GameManager.instance.NoteHit("Perfect");
                    }

                    else if (Mathf.Abs(activator.transform.position.y - transform.position.y) <= greatThreshold)
                    {
                        Debug.Log("Great Hit");
                        GameManager.instance.NoteHit("Great");
                    }

                    else
                    {
                        Debug.Log("Good Hit");
                        GameManager.instance.NoteHit("Good");
                    }
                }
            }

            if (transform.position.y <= -5)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = true;
            activator = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;
            activator = null;
            GameManager.instance.NoteMissed();
        }
    }
}
