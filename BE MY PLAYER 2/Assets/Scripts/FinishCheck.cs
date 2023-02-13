using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// to be honest this file should be the event manager...
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainHub");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // tell timer to stop
            levelFinished = true;

            // this is super jank, todO: refactor into a event manager i think?
            //SceneManager.LoadScene("MainHub");
        }
    }
}
