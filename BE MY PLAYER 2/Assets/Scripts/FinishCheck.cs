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

    public bool levelOneFinished;
    public bool levelTwoFinished;

    // Start is called before the first frame update

    private int collectableScoreOne;
    private int collectableScoreTwo;
    private double playerTimeOne;
    private double playerTimeTwo;
    private double totalTime;
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
                int totalScore = this.collectableScoreOne + this.collectableScoreTwo;
                totalTime = this.playerTimeOne + this.playerTimeTwo;
                c.SetLastPlayerScore(totalScore); // total score will be the sum of the two levels
                c.SetLastPlayerTime(totalTime); //
            }

            hm.LoadDialogueFromLastCharacter();


        }
    }

    public void setScoresLevelOne(int collectableScoreOne, double time) {
        this.collectableScoreOne = collectableScoreOne;
        this.playerTimeOne = time;
    }

    public void setScoresLevelTwo(int collectableScoreTwo, double time)
    {
        this.collectableScoreOne = collectableScoreTwo;
        this.playerTimeTwo = time;
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
