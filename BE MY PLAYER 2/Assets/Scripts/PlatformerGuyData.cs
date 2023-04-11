using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerGuyData : MonoBehaviour, Character
{
    [Header("First Time")]
    [SerializeField] public TextAsset inkJSON_1;
    [SerializeField] public Sprite portrait_1;
    [SerializeField] public Sprite backgroundImage_1;

    [Header("FirstTime Result: Good")]
    [SerializeField] public TextAsset inkJSON_1_good;
    [SerializeField] public Sprite portrait_1_good;
    [SerializeField] public Sprite backgroundImage_1_good;

    [Header("FirstTime Result: Okay")]
    [SerializeField] public TextAsset inkJSON_1_okay;
    [SerializeField] public Sprite portrait_1_okay;
    [SerializeField] public Sprite backgroundImage_1_okay;

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



    public static PlatformerGuyData instance;

    private const double GOOD_TIME = 20;
    private const double OKAY_TIME = 30;
    // any time higher is bad

    private const int MAX_APPLE_SCORE = 6;
    private const int MID_APPLE_SCORE = 3;


    private int totalCollectableScore;
    private double lastPlayerTime;
    public static bool played;

    // states

    // new result states
    public const string RESULT_GOOD = "RESULT_GOOD";
    public const string RESULT_BAD = "RESULT_BAD";
    public const string RESULT_OKAY = "RESULT_OKAY";

    // new states
    public const string STARTING_FIRST_TIME = "FIRST";


    // current states
    private string currentState;
    public static string playerResultState;

    private Dictionary<string, ArrayList> resultAssetMap = new Dictionary<string, ArrayList>();
    private Dictionary<string, ArrayList> startingSceneAssetMap = new Dictionary<string, ArrayList>();

    // relation to player
    private int relationToPlayer;


    // other metrics
    private int numTimePlayed;

    public static PlatformerGuyData GetInstance()
    {
        return instance;
    }

    public bool GetPlayed()
    {
        return played;
    }

    public void SetPlayed(bool boolean)
    {
        played = boolean;
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
        resultAssetMap.Add(RESULT_GOOD, new ArrayList() { inkJSON_1_good, portrait_1_good, backgroundImage_1_good });
        resultAssetMap.Add(RESULT_BAD, new ArrayList() { inkJSON_1_bad, portrait_1_bad, backgroundImage_1_bad });
        resultAssetMap.Add(RESULT_OKAY, new ArrayList() { inkJSON_1_okay, portrait_1_okay, backgroundImage_1_okay });

        startingSceneAssetMap.Add(STARTING_FIRST_TIME, new ArrayList() { inkJSON_1, portrait_1, backgroundImage_1 });
        numTimePlayed = 0;


        this.relationToPlayer = 5; // starting relationship to the player
    }


    /**
     * This method returns the state when starting the dialogue
     */
    public string GetStartingState()
    {
        return this.currentState;
    }

    /**
     * This method returns the state of character, should be updated after
     * updating the score
     */
    public string GetResultState()
    {
        return playerResultState;
    }

    public void SetRelationToPlayer(int newValue)
    {
        relationToPlayer = newValue;
    }

    public int GetRelationToPlayer()
    {
        return relationToPlayer;
    }

    // uhhh fix this
    public void SetLastPlayerScore(int totalCollectableScore)
    {
        this.totalCollectableScore = totalCollectableScore;
    }

    // overloaded method, to accept the score as the time taken to complete the game
    public void SetLastPlayerTime(double totalTime)
    {
        this.numTimePlayed++;
        this.lastPlayerTime = totalTime;
        DetermineResultState();
    }

    private void DetermineResultState()
    {
        // todo: compare player time against expected times, and upate the states
        Debug.Log(lastPlayerTime);
        Debug.Log(totalCollectableScore);
        played = false;
        if (lastPlayerTime <= GOOD_TIME && totalCollectableScore==MAX_APPLE_SCORE)
        {
            // good dialouge only if all apples + good time
            playerResultState = PlatformerGuyData.RESULT_GOOD;
        } else if (lastPlayerTime <= OKAY_TIME && totalCollectableScore>=MID_APPLE_SCORE)
        {
            // mid dialogue if aobut half
            playerResultState = PlatformerGuyData.RESULT_OKAY;
        } else 
        {
            // bad dialgoue otherwise
            playerResultState = PlatformerGuyData.RESULT_BAD;
        }
        Debug.Log(playerResultState);
    }

    public ArrayList GetStartingAssets()
    {
        return this.startingSceneAssetMap[currentState];
    }

    public ArrayList GetResultAssets()
    {
        return this.resultAssetMap[playerResultState];
    }
    
}