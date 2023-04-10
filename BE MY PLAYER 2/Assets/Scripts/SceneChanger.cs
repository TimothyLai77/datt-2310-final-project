using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator animator;

    private int sceneToLoad;

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
        sceneToLoad = 99;
    }

    public void FadeToScene(int sceneIndex)
    {
        animator.SetTrigger("FadeOut");
        sceneToLoad = sceneIndex;
    }

    
    public void OnFadeComplete()
    {
        if(sceneToLoad != 99)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    
}
