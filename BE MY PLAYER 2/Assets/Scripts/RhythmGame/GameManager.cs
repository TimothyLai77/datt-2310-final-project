using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public bool startPlaying;
    public BeatScroller beatScroller;
    public static GameManager instance;
    private RhythmGirlData rhythmGirlData;
    public enum GAME_STATE
    {
        SongSelection,
        SongPlaying,
        SongFinished
    }

    public GAME_STATE currentGameState;

    public List<Song> songs = new List<Song>();
    public int currentSongIndex = 0;
    public Song currentSelectedSong;

    public AudioSource currentSongAudio; 

    public string[] songDifficulties = { "Easy", "Normal", "Hard" };
    public int currentDifficultyIndex = 0;
    public string currentSongDifficulty;

    public int currentScore;
    public int scorePerNote = 10;

    public int currentMultiplier;
    public int currentCombo;
    public int[] multiplierThresholds;

    public bool invokeMusic = true;
    public float delayMusicBeforeStart;

    public Text scoreText;
    public Text multiplierText, comboText;
    public Text songText, difficultyText;

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
    void Awake()
    {
        instance = this;

        loadSongs();
        if (songs.Count > 0)
        {
            initializeSong(songs[currentSongIndex]);
        }

        currentGameState = GAME_STATE.SongSelection;
        currentSongDifficulty = songDifficulties[currentDifficultyIndex];

        songText.text = "Song: " + currentSelectedSong.title;
        difficultyText.text = "Difficulty: " + currentSongDifficulty;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        perfectHits = 0;
        greatHits = 0;
        goodHits = 0;

        rhythmGirlData = RhythmGirlData.GetInstance();
    }

    void Start()
    {
        loadSongAudioSource();
    }

    void playingMusic()
    {
        Debug.Log("musicStart");
        currentSongAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGameState == GAME_STATE.SongSelection)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            {            
                currentSongIndex = (currentSongIndex == 0) ? songs.Count - 1 : currentSongIndex - 1;
                currentSelectedSong = songs[currentSongIndex];
                songText.text = "Song: " + currentSelectedSong.title;
                loadSongAudioSource();
                Debug.Log("currentSongIndex: " + currentSongIndex);
                Debug.Log("Currently Selected Song: " + currentSelectedSong.title);
                Debug.Log("Current Selected Audio Source: " + currentSongAudio.clip.name);
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            {
                currentSongIndex = (currentSongIndex == songs.Count - 1) ? 0 : currentSongIndex + 1;
                currentSelectedSong = songs[currentSongIndex];
                songText.text = "Song: " + currentSelectedSong.title;
                loadSongAudioSource();
                Debug.Log("currentSongIndex: " + currentSongIndex);
                Debug.Log("Currently Selected Song: " + currentSelectedSong.title);
                Debug.Log("Current Selected Audio Source: " + currentSongAudio.clip.name);
            }
            
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D))
            {
                currentDifficultyIndex = (currentDifficultyIndex == 0) ? songDifficulties.Length - 1 : currentDifficultyIndex - 1;
                currentSongDifficulty = songDifficulties[currentDifficultyIndex];
                difficultyText.text = "Difficulty: " + currentSongDifficulty;
                Debug.Log("Currently Selected Difficulty: " + currentSongDifficulty);
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A))
            {
                currentDifficultyIndex = (currentDifficultyIndex == songDifficulties.Length - 1) ? 0 : currentDifficultyIndex + 1;
                currentSongDifficulty = songDifficulties[currentDifficultyIndex];
                difficultyText.text = "Difficulty: " + currentSongDifficulty;
                Debug.Log("Currently Selected Difficulty: " + currentSongDifficulty);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                currentGameState = GAME_STATE.SongPlaying;
                beatScroller.hasStarted = true;

                songText.gameObject.SetActive(false);
                difficultyText.gameObject.SetActive(false);

                if (invokeMusic)
                {
                    Debug.Log("musicInvoked");
                    Invoke("playingMusic", delayMusicBeforeStart);
                    invokeMusic = false;
                }
            }
        }

        if(currentGameState == GAME_STATE.SongFinished && !currentSongAudio.isPlaying && !resultsScreen.activeInHierarchy || Input.GetKeyDown("escape"))
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

            if (percentHit >= 80)
            {
                rhythmGirlData.SetResultState("GOOD");
            }
            else if (percentHit >= 50)
            {
                rhythmGirlData.SetResultState("OKAY");
            }
            else
            {
                rhythmGirlData.SetResultState("BAD");
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
            currentCombo++;
            if(currentCombo >= multiplierThresholds[currentMultiplier-1])
            {
                currentMultiplier++;
            }
        }

        notesHit++;
    
        multiplierText.text = "Multiplier: x" + currentMultiplier;
        comboText.text = "Combo: " + currentCombo;

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NoteMissed()
    {
        Debug.Log("Note Missed");

        GameObject missHitInstance = Instantiate(MissHit, new Vector3(0, 0, 0), Quaternion.identity);
        missHitInstance.transform.position = AccuracySpawner.transform.position;

        currentMultiplier = 1;
        currentCombo = 0;
        multiplierText.text = "Multiplier: x" + currentMultiplier;
        comboText.text = "Combo: " + currentCombo;

        notesMissed++;
    }

    public void Restart()
    {
        SceneManager.LoadScene("RhythmGame"); //this will have the name of your main game scene
    }

    public void Quit()
    {

        HubManager hm = HubManager.GetInstance();
        Character c = hm.GetLastCharacter();

        // if the last character is set to null, -> only load the minigame, do not save score
        if (!(c is null))
        {
            //Debug.Log("no bug ");
            c.SetLastPlayerScore(this.currentScore); // setting the score also determines which dialouge to load 
        }

        hm.LoadDialogueFromLastCharacter();

        // set the score the player achieved.
        //RhythmGirlData rhythmGirlInstance = RhythmGirlData.GetInstance();
        //rhythmGirlInstance.SetLastPlayerScore(this.currentScore); // updating the score now determines the dialogue outcome
        //iArrayList assets = RhythmGirlData.GetInstance().GetAssets();
        //DialogueManager.GetInstance().EnterDialogueMode((TextAsset) assets[0], (Sprite) assets[1], (Sprite)assets[2]);
        //HubManager.GetInstance().RoomOneButton();
        //Debug.Log(RhythmGirlData.GetInstance().GetState());
        //Debug.Log(RhythmGirlData.GetInstance().GetLastDifficulty());
        //SceneManager.LoadScene("DialogueScene");
    }

    private void loadSongs()
    {
        string songsDirectory = Application.dataPath + "/Music/RhythmGame";
        //Debug.Log(songsDirectory);

        DirectoryInfo dir = new DirectoryInfo(songsDirectory);
        FileInfo[] files = dir.GetFiles("*.json");

        foreach (FileInfo file in files) {
            string songJSON = File.ReadAllText(songsDirectory + "/" + file.Name);

            //Debug.Log(songJSON);

            Song song = Song.CreateFromJSON(songJSON);
            songs.Add(song);
        }
    }

    private void initializeSong(Song song)
    {
        currentSelectedSong = song;
    }

    private void loadSongAudioSource()
    {
        string songAudioSource = currentSelectedSong.audioClip;

        // https://answers.unity.com/questions/668721/how-do-i-assign-audio-files-to-an-audioclip-array.html
        currentSongAudio.clip = (AudioClip) Resources.Load("RhythmGame/" + songAudioSource);
    }
}
