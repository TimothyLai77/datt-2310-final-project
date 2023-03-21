using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    private static PlayerData instance;
    private int rhythmSkill;

    // this one stores the songs and the 2nd map 
    private Dictionary<string, Dictionary<string, ArrayList>> playerScores;

    // names are hard, this one stores the 3 difficulties of one song
    private Dictionary<string, ArrayList> songDifficultyScores;

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

    public void SetLastPlayerScore(int score)
    {
        
    }

    public void DecreaseRhythmSkill(int valueToSubtract)
    {
        this.rhythmSkill -= valueToSubtract;
    }

    public int GetRhythmSkill() 
    {
        return this.rhythmSkill;
    }


}
