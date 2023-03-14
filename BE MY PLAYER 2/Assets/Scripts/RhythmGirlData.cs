using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class acts like a container for all the data each character stores.
 * Load all the references to the ink json files, all the images, all the backgrounds go here.
 * GameHubManager will get this instance and then determine which ones to load into the dialogue scene
 */
public class RhythmGirlData : MonoBehaviour
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

    private int lastPlayerScore; // apparently c# has no null ints
    public const int MIN_SCORE_EASY = 850;
    public const int MIN_SCORE_NORMAL = 2000;
    public const int MIN_SCORE_HARD = 3000;
    private int numTimesPlayed = 0;

    // states 
    public const string FIRST_TIME = "first";
    public const string FIRST_RESULT_BAD = "firstResultBad";
    public const string FIRST_RESULT_GOOD = "firstResultGood";

    private string currentState;
    private List<int> chosenMusicSheet;

    private Dictionary<string, ArrayList> assetMap = new Dictionary<string, ArrayList>();

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

        currentState = FIRST_TIME;

        assetMap.Add(FIRST_TIME, new ArrayList() { inkJSON_1, portrait_1, backgroundImage_1 });
        assetMap.Add(FIRST_RESULT_BAD, new ArrayList() { inkJSON_1_bad, portrait_1_bad, backgroundImage_1 });
        assetMap.Add(FIRST_RESULT_GOOD, new ArrayList() { inkJSON_1_good, portrait_1_good, backgroundImage_1 });
    }


    // use the constant strings above. 
    public void SetState(string state) {
        this.currentState = state;
    }

    public string GetState()
    {
        return this.currentState;
    }

    public void SetLastPlayerScore(int score)
    {
        this.numTimesPlayed++;
        this.lastPlayerScore = score;

        DetermineState();
    }

    public void SetDifficulty(List<int> musicSheet)
    {
        this.chosenMusicSheet = musicSheet;
    }

    private void DetermineState()
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
                SetState(RhythmGirlData.FIRST_RESULT_GOOD);
                return;
            }

        }
        else if (chosenMusicSheet.Equals(normal))
        {
            // 86 notes total, 2000 is a nice threshold.
            if(lastPlayerScore >= MIN_SCORE_NORMAL)
            {
                SetState(RhythmGirlData.FIRST_RESULT_GOOD);
                return;
            }
        }
        else if(chosenMusicSheet.Equals(easy))
        {
            // 53 notes for easy, 800
            if(lastPlayerScore >= MIN_SCORE_EASY)
            {
                SetState(RhythmGirlData.FIRST_RESULT_GOOD);
                return;
            }
        }
        SetState(RhythmGirlData.FIRST_RESULT_BAD);
    }




    public ArrayList GetAssets()
    {
        return assetMap[currentState];
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
