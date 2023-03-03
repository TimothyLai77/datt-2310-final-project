using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HubClickInput : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Clicked at position: " + clickPosition);

            // Check if the click was on a specific spot
            if (clickPosition.x >= -22.27f && clickPosition.x <= -10.64f)
            if (clickPosition.y >= -1.85f && clickPosition.y <= 6.68f)
            {
                // Load the next scene
                SceneManager.LoadScene("platformerDemo", LoadSceneMode.Single);
            }

            if (clickPosition.x >= -10.52f && clickPosition.x <= -2.06f)
            if (clickPosition.y >= -1.85f && clickPosition.y <= 6.68f)
            {
                    // Load the next scene
                    SceneManager.LoadScene("RhythmGame", LoadSceneMode.Single);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                SceneManager.UnloadSceneAsync("platformerDemo");
                SceneManager.UnloadSceneAsync("RhythmGame");
                SceneManager.LoadScene("MainHub", LoadSceneMode.Single);
            }
        }
    }
}
