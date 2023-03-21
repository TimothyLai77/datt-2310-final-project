using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class acts like a container for all the data each character stores.
 * Load all the references to the ink json files, all the images, all the backgrounds go here.
 * GameHubManager will get this instance and then determine which ones to load into the dialogue scene
 */
public class RhythmGirlData : MonoBehaviour, Character
{


    private static RhythmGirlData instance;
    
    // these variable names kinda break convention but its easier to read...
    [Header("First Time")]
    [SerializeField] public TextAsset inkJSON_1;
    [SerializeField] public Sprite portrait_1;
    [SerializeField] public Sprite backgroundImage_1;

    [Header("FirstTime Result: Good")]
    [SerializeField] public TextAsset inkJSON_1_good;
    [SerializeField] public Sprite portrait_1_good;
    [SerializeField] public Sprite backgroundImage_1_good;

    [Header("FirstTime Result: Bad")]
    [SerializeField] public TextAsset inkJSON_1_bad;
    [SerializeField] public Sprite portrait_1_bad;
    [SerializeField] public Sprite backgroundImage_1_bad;


    [Header("Second Time")]
    [SerializeField] public TextAsset inkJSON_2;
    [SerializeField] public Sprite portrait_2;
    [SerializeField] public Sprite backgroundImage_2;

    [Header("SecondTime Result: Good")]
    [SerializeField] public TextAsset inkJSON_2_good;
    [SerializeField] public Sprite portrait21_good;
    [SerializeField] public Sprite backgroundImage_2_good;

    [Header("SecondTime Result: Bad")]
    [SerializeField] public TextAsset inkJSON_2_bad;
    [SerializeField] public Sprite portrait_2_bad;
    [SerializeField] public Sprite backgroundImage_2_bad;



    private int lastPlayerScore; // apparently c# has no null ints
    public const int MIN_SCORE_EASY = 1200;
    public const int MIN_SCORE_NORMAL = 2000;
    public const int MIN_SCORE_HARD = 3000;
    private int numTimesPlayed = 0;

    // states
    //public const string FIRST_TIME = "first";
    public const string FIRST_RESULT_BAD = "firstResultBad";
    public const string FIRST_RESULT_GOOD = "firstResultGood";

    // new result states
    public const string RESULT_GOOD = "RESULT_GOOD";
    public const string RESULT_BAD = "RESULT_BAD";

    // new states
    public const string STARTING_FIRST_TIME = "FIRST";

    private const int NETURAL_RELATIONSHIP = 5;
    private const int POSITIVE_RELATIONSHIP = 7;
    private const int NEGATIVE_RELATIONSHIP = 3;

    private int relationToPlayer; 

    private string currentState; // determines which starting dialogue to load
    private string playerResultState; // determines which result dialogue to play


    private List<int> chosenMusicSheet;

    private Dictionary<string, ArrayList> assetMap = new Dictionary<string, ArrayList>();

    private Dictionary<string, ArrayList> resultAssetMap = new Dictionary<string, ArrayList>();
    private Dictionary<string, ArrayList> startingSceneAssetMap = new Dictionary<string, ArrayList>();




    //private Dictionary<int, ArrayList> assetMap = new Dictionary<int, ArrayList>();
    public static RhythmGirlData GetInstance()
    {
        return instance;
    }

    private void Awake()
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

        currentState = STARTING_FIRST_TIME;

        // init the starting map values
        resultAssetMap.Add(RESULT_GOOD, new ArrayList() { inkJSON_1_good, portrait_1_good, backgroundImage_1_good});
        resultAssetMap.Add(RESULT_BAD, new ArrayList() { inkJSON_1_bad, portrait_1_bad, backgroundImage_1_bad });

        startingSceneAssetMap.Add(STARTING_FIRST_TIME, new ArrayList() { inkJSON_1, portrait_1, backgroundImage_1});

        //assetMap.Add(FIRST_TIME, new ArrayList() { inkJSON_1, portrait_1, backgroundImage_1 });
        //assetMap.Add(FIRST_RESULT_BAD, new ArrayList() { inkJSON_1_bad, portrait_1_bad, backgroundImage_1 });
        //assetMap.Add(FIRST_RESULT_GOOD, new ArrayList() { inkJSON_1_good, portrait_1_good, backgroundImage_1 });
        this.relationToPlayer = 5; // starting relationship to the player
        //assetMap.Add(NETURAL_RELATIONSHIP, new ArrayList() { inkJSON_1})
    }


    // use the constant strings above. 
    //public void SetState(string state) {
    //    this.currentState = state;
    //}


    public string GetStartingState()
    {
        return this.currentState;
    }

    public string GetResultState()
    {
        return this.playerResultState;
    }

    public void SetRelationToPlayer(int newValue) 
    {
        this.relationToPlayer = newValue;
    }

    public int GetRelationToPlayer()
    {
        return this.relationToPlayer;
    }

    public void SetLastPlayerScore(int score)
    {
        this.numTimesPlayed++;
        this.lastPlayerScore = score;

        DetermineResultState();
    }

    public void SetDifficulty(List<int> musicSheet)
    {
        this.chosenMusicSheet = musicSheet;
    }

    ///**
    // * Method used for debugging. Don't really need it. 
    // */
    //public string GetLastDifficulty()
    //{
    //    List<int> easy = MusicCharts.epicSongEasy;
    //    List<int> normal = MusicCharts.epicSongNormal;
    //    List<int> hard = MusicCharts.epicSongHard;

    //    if (chosenMusicSheet.Equals(hard))
    //    {
    //        return "hard was picked";

    //    }
    //    else if (chosenMusicSheet.Equals(normal))
    //    {
    //        return "normal was picked";
    //    }
    //    else if (chosenMusicSheet.Equals(easy))
    //    {
    //        return "easy was picked";
    //    }
    //    else
    //    {
    //        return null;
    //    }
    //}


    private void DetermineResultState()
    {
        // C# does reference checking on List.Equals (I think)
        // should be pretty fast to compare the sheets. 
        List<int> easy = MusicCharts.epicSongEasy;
        List<int> normal = MusicCharts.epicSongNormal;
        List<int> hard = MusicCharts.epicSongHard;


        if (chosenMusicSheet.Equals(hard))
        {
            // 164 notes for hard, 3000 should be good
          
            if (lastPlayerScore >= MIN_SCORE_HARD)
            {
                playerResultState = RhythmGirlData.RESULT_GOOD;
                return;
            }

        }
        else if (chosenMusicSheet.Equals(normal))
        {
            // 86 notes total, 2000 is a nice threshold.
            if(lastPlayerScore >= MIN_SCORE_NORMAL)
            {
                playerResultState = RhythmGirlData.RESULT_GOOD;
                return;
            }
        }
        else if(chosenMusicSheet.Equals(easy))
        {
            // 53 notes for easy, 800
            if(lastPlayerScore >= MIN_SCORE_EASY)
            {
                playerResultState = RhythmGirlData.RESULT_GOOD;
                return;
            }
        }
        playerResultState = RhythmGirlData.RESULT_BAD;
    }




    //public ArrayList GetAssets()
    //{
    //    return assetMap[currentState];
    //}

    public ArrayList GetStartingAssets()
    { 
        return this.startingSceneAssetMap[currentState];
    }

    public ArrayList GetResultAssets()
    {
        return this.resultAssetMap[playerResultState];
    }

    public override string ToString()
    {
        return "rhythmGirl";
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
