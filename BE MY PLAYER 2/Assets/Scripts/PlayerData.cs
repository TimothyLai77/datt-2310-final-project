using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerData instance;

    public static int viewers;
    private int increase;
    public static int mattRelationship = 5;
    public static int alexRelationship = 5;

    public static int rhythmGameSkill = 0;
    public static int platformerGameSkill = 0;

    // max relationship is 10, player starts at 5.
    public const int MAX_RELATIONSHIP = 10;

    // max player skill for both games is 10, player starts at 0 for both games.
    public const int MAX_SKILL = 10;

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

        // it'll reset everytimer on load but i guess that's fine?
    }

    // Use this when trying to use this class. Example: PlayerData.GetInstance().SetViewers(1000); sets the viewer count to 1000. 
    public static PlayerData GetInstance()
    {
        return instance;
    }

    public int GetViewers() 
    {
        return viewers;
    }

    public void SetViewers(int newViewers)
    {
        viewers = newViewers;
    }

    public void SetIncrease(int newViewers)
    {
        viewers += newViewers;
    }

    public int GetMattRelationship() 
    {
        return mattRelationship;
    }

    public void IncreaseMattRelationship(int newRelationship) 
    {
        mattRelationship += newRelationship;
        if(mattRelationship < 0) 
        {
            mattRelationship = 0;
        }
        if(mattRelationship > 20)
        {
            mattRelationship = 20;
        }

    }

    public int GetAlexRelationship()
    {
        return alexRelationship;
    }

    public void IncreaseAlexRelationship(int newRelationship)
    {
        alexRelationship += newRelationship;
        if(alexRelationship < 0) 
        {
            alexRelationship = 0;
        }
        if(alexRelationship > 20)
        {
            alexRelationship = 20;
        }
    }

    public int GetRyhthmGameSkill() 
    {
        return rhythmGameSkill;
    }

    public void IncreaseRyhthmGameSkill(int newSkill) 
    {
        rhythmGameSkill += newSkill;
        if(rhythmGameSkill > 20)
        {
            rhythmGameSkill = 20;
        }
    }

    public int GetPlatformerGameSkill()
    {
        return platformerGameSkill;
    }

    public void IncreasePlatformerGameSkill(int newSkill)
    {
        platformerGameSkill += newSkill;
        if(platformerGameSkill > 20)
        {
            platformerGameSkill = 20;
        }
    }
}
