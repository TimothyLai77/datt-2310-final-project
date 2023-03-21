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
    private float perfectHits;
    private float greatHits;
    private float goodHits;


    private float movingSpeed = -205f;
    private Vector3 movingVec = new Vector3(-0.004f, 0f, 0f);
    private Vector3 background1Ini = new Vector3(-0.4f, 4f, 0f);
    private Vector3 background2Ini = new Vector3(20f, 4f, 0f);
    public GameObject background1;
    public GameObject background2;
    private float backgroundTimer;
    private float backgroundRef;
    public float BackgroundMovingSpeed = 1f; //higher means slower

    //private int calledTime = 0;//test

    public GameObject resultsScreen;
    public Text percentHitText, notesHitText, notesMissedText, finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        perfectHits = 0;
        greatHits = 0;
        goodHits = 0;

        backgroundTimer = 0;
        backgroundRef = 5f;
        //calledTime = 0; //test
        movingSpeed = movingSpeed/50f/BackgroundMovingSpeed;
        movingVec = new Vector3(movingSpeed, 0f, 0f);
        //Debug.Log("movingSpeed:"+movingSpeed);

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
            if(Input.anyKeyDown)
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
        backgroundMoving();

        
    }

    public void backgroundMoving()
    {
        background1.transform.position = background1Ini;
        background2.transform.position = background2Ini;
        background1Ini = background1Ini + movingVec*Time.deltaTime;
        background2Ini = background2Ini + movingVec*Time.deltaTime;
        //Debug.Log(background1Ini);
        backgroundTimer += Time.deltaTime;
        //calledTime++; //test
        if (backgroundTimer >= backgroundRef * BackgroundMovingSpeed)
        {
            //Debug.Log(background1Ini + "attime" + backgroundTimer +"called" + calledTime); //test
            //calledTime = 0; //test
            backgroundTimer = 0f;
            background1Ini = new Vector3(-0.4f, 4f, 0f);
            background2Ini = new Vector3(20f, 4f, 0f); 
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
        SceneManager.LoadScene("MainHub");
    }
}
