using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    private static PlayerData instance;
    private int rhythmSkill;
    private int viewers;

    // <string, Dictionary<string, arraylist>> --> <songName, ArrayList<difficulty, scoreHistory[100, 2000, 10000, 241242, etc.]>>.

    private Dictionary<string, ArrayList> difficultyLists; // ex. <EASY, [123,4525,5735,134]>

    private Dictionary<string, Dictionary<string, ArrayList>> rhythmGameScores;

    // when inserting and extracting scores into this class, use these constants. 
    public const string SONG_1 = "SONG_1"; // replace these with the actual song names later
    public const string SONG_2 = "SONG_2";

    public const string HARD = "HARD";
    public const string NORMAL = "NORMAL";
    public const string EASY = "EASY";


    void Awake()
    {
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
        // on wake, init the relationships and skill
        this.rhythmSkill = 0;

        // for now.. (which means this will never get fixed) hard code the song titles and difficulties.
        rhythmGameScores = new Dictionary<string, Dictionary<string, ArrayList>>();

        rhythmGameScores.Add(SONG_1, new Dictionary<string, ArrayList>());
        rhythmGameScores[SONG_1].Add(EASY, new ArrayList());
        rhythmGameScores[SONG_1].Add(NORMAL, new ArrayList());
        rhythmGameScores[SONG_1].Add(HARD, new ArrayList());

        rhythmGameScores.Add(SONG_2, new Dictionary<string, ArrayList>());
        rhythmGameScores[SONG_2].Add(EASY, new ArrayList());
        rhythmGameScores[SONG_2].Add(NORMAL, new ArrayList());
        rhythmGameScores[SONG_2].Add(HARD, new ArrayList());

    }

    public PlayerData GetInstance()
    {
        return instance;
    }

    
    
    /**
     * Method that increase the player's skill by valueToAdd amount
     */
    public void IncreaseRhythmSkill(int valueToAdd) 
    {
        this.rhythmSkill += valueToAdd;
    }

    /**
     * Sets the player score for a song's difficulty. Use the constants above 
     */
    public void RhythmSetLastPlayerScore(string songName, string difficulty, int score)
    {
        Dictionary<string, ArrayList> songSelected = rhythmGameScores[songName];
        ArrayList difficultySelected = songSelected[difficulty];
        difficultySelected.Add(score);
    }

    /*
     * Returns an arraylist that gets all the scores for a song's difficulty. 
     */
    public ArrayList RhythmGetPlayerScores(string songName, string difficulty)
    {
        Dictionary<string, ArrayList> songSelected = rhythmGameScores[songName];
        return songSelected[difficulty];
    }

    

    public void DecreaseRhythmSkill(int valueToSubtract)
    {
        this.rhythmSkill -= valueToSubtract;
    }

    public int GetRhythmSkill() 
    {
        return this.rhythmSkill;
    }

    public void SetViewers(int newViewerCount)
    {
        this.viewers = newViewerCount;
    }

    public int GetViewers()
    {
        return this.viewers;
    }

}
