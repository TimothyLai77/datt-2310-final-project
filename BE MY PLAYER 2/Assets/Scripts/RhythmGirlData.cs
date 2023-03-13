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

    private int lastPlayerScore;
    private const int MIN_SCORE = 2000;


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
    }

    public void SetLastPlayerScore(int score)
    {
        this.lastPlayerScore = score;
    }

    // pain...fix later....
    public ArrayList GetAssets()
    {
        if(lastPlayerScore >= MIN_SCORE)
        {
            return new ArrayList() { inkJSON_1_good, portrait_1_good, backgroundImage_1_good };
        }else if(lastPlayerScore < MIN_SCORE)
        {
            return new ArrayList() { inkJSON_1_bad, portrait_1_bad, backgroundImage_1_bad };
        }
        else
        {
            return new ArrayList() { inkJSON_1, portrait_1, backgroundImage_1 };
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
