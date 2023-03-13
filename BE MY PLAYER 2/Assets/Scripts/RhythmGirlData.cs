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
    [SerializeField] public TextAsset inkJSON_2_good;
    [SerializeField] public Sprite portrait_2_good;
    [SerializeField] public Sprite backgroundImage_2_good;

    [Header("FirstTime Result: Bad")]
    [SerializeField] public TextAsset inkJSON_2_bad;
    [SerializeField] public Sprite portrait_2_bad;
    [SerializeField] public Sprite backgroundImage_2_bad;


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



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
