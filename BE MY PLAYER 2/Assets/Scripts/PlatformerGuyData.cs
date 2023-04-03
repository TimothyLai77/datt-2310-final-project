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



    private static PlatformerGuyData instance;


    private double lastPlayerTime;

    // states

    // new result states
    public const string RESULT_GOOD = "RESULT_GOOD";
    public const string RESULT_BAD = "RESULT_BAD";
    public const string RESULT_OKAY = "RESULT_OKAY";

    // new states
    public const string STARTING_FIRST_TIME = "FIRST";


    // current states
    private string currentState;
    private string playerResultState;

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

    // uhhh fix this
    public void SetLastPlayerScore(int time)
    {
        return;
    }

    // overloaded method, to accept the score as the time taken to complete the game
    public void SetLastPlayerScore(double time)
    {
        this.numTimePlayed++;
        this.lastPlayerTime = time;
        DetermineResultState();
    }

    private void DetermineResultState()
    {
        // todo: compare player time against expected times, and upate the states
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