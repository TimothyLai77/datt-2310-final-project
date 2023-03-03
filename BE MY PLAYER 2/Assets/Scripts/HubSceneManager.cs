using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("platformerDemo");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("RhythmGame");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            SceneManager.UnloadSceneAsync("platformerDemo");
            SceneManager.UnloadSceneAsync("RhythmGame");
            SceneManager.LoadScene("MainHub", LoadSceneMode.Single);
        }
    }
}
