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

    public GameObject resultsScreen;
    public Text percentHitText, notesHitText, notesMissedText, finalScoreText, perfectHitsText, greatHitsText, goodHitsText;

    [SerializeField] public GameObject difficultySelectorPanel;

    [SerializeField] private GameObject AccuracySpawner;
    [SerializeField] private GameObject PerfectHit;
    [SerializeField] private GameObject GreatHit;
    [SerializeField] private GameObject GoodHit;
    [SerializeField] private GameObject MissHit;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        perfectHits = 0;
        greatHits = 0;
        goodHits = 0;

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
                this.difficultySelectorPanel.SetActive(false); // hide difficult select prompt
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

                perfectHitsText.text = perfectHits.ToString();
                greatHitsText.text = greatHits.ToString();
                goodHitsText.text = goodHits.ToString();
            }
        }
    }

    public void NoteHit(string accuracy)
    {
        if(accuracy == "Perfect")
        {
            GameObject perfectHitInstance = Instantiate(PerfectHit, new Vector3(0, 0, 0), Quaternion.identity);
            perfectHitInstance.transform.position = AccuracySpawner.transform.position;
            perfectHits++;
        }
        else if (accuracy == "Great")
        {
            GameObject greatHitInstance = Instantiate(GreatHit, new Vector3(0, 0, 0), Quaternion.identity);
            greatHitInstance.transform.position = AccuracySpawner.transform.position;
            greatHits++;
        }
        else if (accuracy == "Good")
        {
            GameObject goodHitInstance = Instantiate(GoodHit, new Vector3(0, 0, 0), Quaternion.identity);
            goodHitInstance.transform.position = AccuracySpawner.transform.position;
            goodHits++;
        }

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

        GameObject missHitInstance = Instantiate(MissHit, new Vector3(0, 0, 0), Quaternion.identity);
        missHitInstance.transform.position = AccuracySpawner.transform.position;

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
        HubManager hb = HubManager.GetInstance();
        if (hb.MinigameStarted())
        {
            // player only wants to play game, no dialogue after, just load back to hub
            SceneManager.LoadScene("MainHub");
        }
        else
        {
            // player chose to spend time with someone, load dialouge after
            // set the score the player achieved.
            RhythmGirlData rhythmGirlInstance = RhythmGirlData.GetInstance();
            rhythmGirlInstance.SetLastPlayerScore(this.currentScore); // updating the score now determines the dialogue outcome
            hb.RoomOneButton(); // super jank way
        }
    }
}
