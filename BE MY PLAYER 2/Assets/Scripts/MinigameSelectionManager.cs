using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MinigameSelectionManager : MonoBehaviour
{
    private static MinigameSelectionManager instance;

    public SceneChanger sceneChanger;

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
        sceneChanger.FadeToScene(2);
    }

    public void StartPlatformerGame()
    {
        sceneChanger.FadeToScene(3);
    }

    public void ReturnToHub()
    {
        sceneChanger.FadeToScene(1);
    }


    public static MinigameSelectionManager GetInstance()
    {
        return instance;
    }
}
