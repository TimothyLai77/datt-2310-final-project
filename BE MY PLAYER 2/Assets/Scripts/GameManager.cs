using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 10;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public bool invokeMusic = true;
    private bool afterMusic = false;
    public float delayMusicBeforeStart;

    public Text scoreText;
    public Text multiplierText;

    public float notesHit;
    public float notesMissed;
    public float totalNotes;
    public float percentHit;

    public GameObject resultsScreen;
    public Text percentHitText, notesHitText, notesMissedText, finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
    }

    void playingMusic()
    {
        Debug.Log("musicStart");
        theMusic.Play();
        afterMusic = true;
    }



    // Update is called once per frame
    void Update()
    {
        

        if(!startPlaying)
        {
            // super jank fix later
            if (Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3")) 
            {
                startPlaying = true;
                theBS.hasStarted = true;
                if (invokeMusic)
                {
                    Debug.Log("musicInvoked");
                    Invoke("playingMusic", delayMusicBeforeStart);
                    invokeMusic = false;
                }
                //theMusic.Play();
            }
        }
        else 
        {
            if(afterMusic && !theMusic.isPlaying && !resultsScreen.activeInHierarchy || Input.GetKeyDown("escape"))
            {
                resultsScreen.SetActive(true);

                notesHitText.text = notesHit.ToString();
                notesMissedText.text = notesMissed.ToString();

                float totalNotes = notesHit + notesMissed;
                float percentHit = (notesHit / totalNotes) * 100f;
                
                percentHitText.text = percentHit.ToString("F1") + "%";
                finalScoreText.text = currentScore.ToString();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        if(currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if(multiplierThresholds[currentMultiplier-1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        notesHit++;
    
        multiplierText.text = "Multiplier: x" + currentMultiplier;

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NoteMissed()
    {
        Debug.Log("Note Missed");

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiplierText.text = "Multiplier: x" + currentMultiplier;

        notesMissed++;
    }

    public void Restart()
    {
        SceneManager.LoadScene("RhythmGame"); //this will have the name of your main game scene
    }

    public void Quit()
    {
        // set the score the player achieved.
        RhythmGirlData rhythmGirlInstance = RhythmGirlData.GetInstance();
        rhythmGirlInstance.SetLastPlayerScore(this.currentScore); // updating the score now determines the dialogue outcome
        //iArrayList assets = RhythmGirlData.GetInstance().GetAssets();
        //DialogueManager.GetInstance().EnterDialogueMode((TextAsset) assets[0], (Sprite) assets[1], (Sprite)assets[2]);
        HubManager.GetInstance().RoomOneButton();
        //Debug.Log(RhythmGirlData.GetInstance().GetState());
        //Debug.Log(RhythmGirlData.GetInstance().GetLastDifficulty());
        //SceneManager.LoadScene("DialogueScene");
    }
}
