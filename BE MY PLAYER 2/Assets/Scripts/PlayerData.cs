using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    private static PlayerData instance;
    private int rhythmSkill;

    private const int STARTING_RELATIONSHIP = 5;

    // honestly there should be an abstract character class and have RhythmGirl, etc. as children
    // then I can avoid using strings + excess variables but i'm too lazy to redo that...
    public const string RHYTHM_GIRL = "RhythmGirl";
    private Dictionary<string, int> relationships = new Dictionary<string, int>();




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
        this.relationships.Add(RHYTHM_GIRL, STARTING_RELATIONSHIP);
        this.rhythmSkill = 0; 
    }

    public PlayerData GetInstance()
    {
        return instance;
    }


    public void SetRelationship(string character, int value)
    {
        relationships[character] = value;
    }

    public void IncreaseRhythmSkill(int value) 
    {
        this.rhythmSkill += value;
    }

    public int GetRhythmSkill() 
    {
        return this.rhythmSkill;
    }


    /**
     * Returns the relationship to the character, please use the constants 
     */
    public int GetRelationship(string character)
    {
        return relationships[character];
    }
}
