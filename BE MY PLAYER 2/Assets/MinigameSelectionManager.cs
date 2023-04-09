using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MinigameSelectionManager : MonoBehaviour
{
    private static MinigameSelectionManager instance;

    private void Awake()
    {
        /*
         * only add the instance to Unity's DontDestroyOnLoad Scene
         * if it doesn't exist, otherwise don't do anything. 
         */
        if (instance != null && instance != this)
        {
            // if instance is null and there is another instance
            Destroy(this.gameObject);
        }
        else
        {
            // if instance is null set the instance to this object
            instance = this;
        }
    }

    public void StartRhythmGame() 
    {
        SceneManager.LoadScene("RhythmGame");
    }

    public void StartPlatformerGame()
    {
        SceneManager.LoadScene("platformerDemo");
    }

    public void ReturnToHub()
    {
        SceneManager.LoadScene("MainHub");
    }


    public static MinigameSelectionManager GetInstance()
    {
        return instance;
    }
}
