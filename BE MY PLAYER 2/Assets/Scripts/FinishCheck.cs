using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// to be honest this file should be the event manager...
public class FinishCheck : MonoBehaviour
{

    public GameObject player;
    public bool levelFinished;
    public SoundFX sound;
    // Start is called before the first frame update

    private int appleScore;
    private double playerTime;

    void Start()
    {
        levelFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene("MainHub");

            HubManager hm = HubManager.GetInstance();
            PlatformerGuyData c = (PlatformerGuyData) hm.GetLastCharacter();

            // if the last character is set to null, -> only load the minigame, do not save score
            if (!(c is null))
            {
                
                c.SetLastPlayerScore(appleScore);
                c.SetLastPlayerTime(playerTime);
            }

            hm.LoadDialogueFromLastCharacter();


        }
    }

    public void setScores(int appleScore, double time) {
        this.appleScore = appleScore;
        this.playerTime = time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // tell timer to stop
            if(levelFinished == false)
            {
                sound.CheckpointFinishSound();
            }
            levelFinished = true;
            
            // this is super jank, todO: refactor into a event manager i think?
            //SceneManager.LoadScene("MainHub");
        }
    }
}
