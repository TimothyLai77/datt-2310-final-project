using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    private static PlayerData instance;

    private int viewers;
    private int mattRelationship;
    private int alexRelationship;

    private int rhythmGameSkill;
    private int platformerGameSkill;

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
        this.viewers = 0;
        this.mattRelationship = 5;
        this.alexRelationship = 5;
        this.rhythmGameSkill = 0;
        this.platformerGameSkill = 0;
    }

    // Use this when trying to use this class. Example: PlayerData.GetInstance().SetViewers(1000); sets the viewer count to 1000. 
    public PlayerData GetInstance()
    {
        return instance;
    }





    public int GetViewers() 
    {
        return this.viewers;
    }

    public void SetViewers(int newViewers)
    {
        this.viewers = newViewers;
    }

    public int GetMattRelationship() 
    {
        return this.mattRelationship;
    }

    public void SetMattRelationship(int newRelationship) 
    {
        this.mattRelationship = newRelationship;
    }

    public int GetAlexRelationship()
    {
        return this.alexRelationship;
    }

    public void SetAlexRelationship(int newRelationship)
    {
        this.alexRelationship = newRelationship;
    }

    public int GetRyhtmGameSkill() 
    {
        return this.rhythmGameSkill;
    }

    public void SetRyhthmGameSkill(int newSkill) 
    {
        this.rhythmGameSkill = newSkill;
    }

    public int GetPlatformerGameSkill()
    {
        return this.platformerGameSkill;
    }

    public void SetPlatformerGameSkill(int newSkill)
    {
        this.platformerGameSkill = newSkill;
    }
}
