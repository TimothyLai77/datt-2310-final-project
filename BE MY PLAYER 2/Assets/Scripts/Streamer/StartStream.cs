using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartStream : MonoBehaviour
{
    public void LoadScene() 
    {
        SceneManager.LoadScene("Stream");
    }
}
