using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// to be honest this file should be the event manager...
public class FinishCheck : MonoBehaviour
{

    public GameObject player;
    public bool levelFinished;

    public DeathScript deathScript;
    public Timer timer;

    public GameObject resultsScreen;
    public Text deathsText, finalTimeText;
    public static Text gradeText;
    
    // Start is called before the first frame update
    void Start()
    {
        levelFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelFinished == true || Input.GetKeyDown(KeyCode.Escape))
        {
            resultsScreen.SetActive(true);
            deathsText.text = deathScript.deaths.ToString();
            float finalTime = timer.currentTime;
            if(levelFinished != true) 
            {
                finalTimeText.text = "N/A";
                gradeText.text = "F";
            }
            else 
            {
                finalTimeText.text = finalTime.ToString("F2");
                if(finalTime < 14) {
                    gradeText.text = "S";
                }
                else if(finalTime < 15) {
                    gradeText.text = "A";
                }
                else if(finalTime < 17) {
                    gradeText.text = "B";
                }
                else if(finalTime < 20) {
                    gradeText.text = "C";
                }
                else {
                    gradeText.text = "F";
                }
            }
            
            
            //SceneManager.LoadScene("MainHub");
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

    public void Restart()
    {
        SceneManager.LoadScene("platformerDemo"); 
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainHub");
    }
}
