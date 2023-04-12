using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HubManager : MonoBehaviour
{


    [Header("FOR DEBUG AND TESTING DIALOGUE")]
    [SerializeField] public TextAsset inkJSON_DEBUG;
    [SerializeField] public Sprite portrait_DEBUG;
    [SerializeField] public Sprite backgroundImage_DEBUG;

    [Header("INTRO DIALOGUE")]
    [SerializeField] public TextAsset inkJSON_hubIntro;
    [SerializeField] public Sprite portrait_hubIntro;
    [SerializeField] public Sprite backgroundImage_hubIntro;
    private static HubManager instance;

    private bool minigameStarted;
    public Text statsText;
    public GameObject statsScreen;

    public SceneChanger sceneChanger;

    // Getter method to access the instance of this manager
    public static HubManager GetInstance()
    {
        return instance;
    }

    // not super clean but set these when the button is pressed
    private TextAsset inkToLoad; // this is just pain...
    private Sprite portraitToLoad;
    private Sprite backgroundImageToLoad;
    private Character lastCharacter;

    private void Awake()
    {
        /*
         * only add the instance to Unity's DontDestroyOnLoad Scene
         * if it doesn't exist, otherwise don't do anything. 
         */
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
        this.lastCharacter = null;
        ShowIntro();
    }


    void Start()
    {
    }

    private void ShowIntro() { 
        if(TitleScreenManager.introShown == false)
        {
            TitleScreenManager.introShown = true;
            SetToLoads(inkJSON_hubIntro, portrait_hubIntro, backgroundImage_hubIntro);
            SceneManager.LoadScene("DialogueScene");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RoomOneButton()
    {
        // room one = rhythmGirl.
        // set that as the last cahracter talked to 
        this.lastCharacter = RhythmGirlData.GetInstance();
        ArrayList assetsToLoad = (this.lastCharacter).GetStartingAssets(); // get the assets
        // load the references so the dialogueManger can grab the asset references
        SetToLoads((TextAsset)assetsToLoad[0],(Sprite) assetsToLoad[1], (Sprite)assetsToLoad[2]);
        sceneChanger.FadeToScene(4); // switch to dialogue
    }

    public void RoomTwoButton()
    {
        this.lastCharacter = PlatformerGuyData.GetInstance();
        ArrayList assetsToLoad = (this.lastCharacter).GetStartingAssets();
        SetToLoads((TextAsset)assetsToLoad[0], (Sprite)assetsToLoad[1], (Sprite)assetsToLoad[2]);
        sceneChanger.FadeToScene(4); // swithc to dialogue
    }

    public void MyRoomButton() 
    {
        this.lastCharacter = null; // so it returns to hub w/o dialogue scene after game
        sceneChanger.FadeToScene(5);
    }

    public void StatsButton()
    {
        string mattLevel, alexLevel, viewerLevel, rhythmLevel, platformerLevel;
        if(PlayerData.GetInstance().GetMattRelationship() <= 3)
        {
            mattLevel = "(Unfriendly)";
        }
        else if(PlayerData.GetInstance().GetMattRelationship() <= 8)
        {
            mattLevel = "(Neutral)";
        }
        else if(PlayerData.GetInstance().GetMattRelationship() <= 13)
        {
            mattLevel = "(Friendly)";
        }
        else if(PlayerData.GetInstance().GetMattRelationship() <= 18)
        {
            mattLevel = "(Trusted)";
        }
        else
        {
            mattLevel = "(Best Friends)";
        }

        if(PlayerData.GetInstance().GetAlexRelationship() <= 3)
        {
            alexLevel = "(Unfriendly)";
        }
        else if(PlayerData.GetInstance().GetAlexRelationship() <= 8)
        {
            alexLevel = "(Neutral)";
        }
        else if(PlayerData.GetInstance().GetAlexRelationship() <= 13)
        {
            alexLevel = "(Friendly)";
        }
        else if(PlayerData.GetInstance().GetAlexRelationship() <= 18)
        {
            alexLevel = "(Trusted)";
        }
        else
        {
            alexLevel = "(Best Friends)";
        }

        if(PlayerData.GetInstance().GetViewers() <= 30)
        {
            viewerLevel = "(Newbie)";
        }
        else if(PlayerData.GetInstance().GetViewers() <= 80)
        {
            viewerLevel = "(Average)";
        }
        else if(PlayerData.GetInstance().GetViewers() <= 150)
        {
            viewerLevel = "(Above Average)";
        }
        else if(PlayerData.GetInstance().GetViewers() <= 250)
        {
            viewerLevel = "(Popular)";
        }
        else
        {
            viewerLevel = "(Famous)";
        }

        if(PlayerData.GetInstance().GetRyhthmGameSkill() <= 3)
        {
            rhythmLevel = "(Beginner)";
        }
        else if(PlayerData.GetInstance().GetRyhthmGameSkill() <= 8)
        {
            rhythmLevel = "(Mediocre)";
        }
        else if(PlayerData.GetInstance().GetRyhthmGameSkill() <= 13)
        {
            rhythmLevel = "(Intermediate)";
        }
        else if(PlayerData.GetInstance().GetRyhthmGameSkill() <= 17)
        {
            rhythmLevel = "(Advanced)";
        }
        else
        {
            rhythmLevel = "(Pro)";
        }

        if(PlayerData.GetInstance().GetPlatformerGameSkill() <= 3)
        {
            platformerLevel = "(Beginner)";
        }
        else if(PlayerData.GetInstance().GetPlatformerGameSkill() <= 8)
        {
            platformerLevel = "(Mediocre)";
        }
        else if(PlayerData.GetInstance().GetPlatformerGameSkill() <= 13)
        {
            platformerLevel = "(Intermediate)";
        }
        else if(PlayerData.GetInstance().GetPlatformerGameSkill() <= 17)
        {
            platformerLevel = "(Advanced)";
        }
        else
        {
            platformerLevel = "(Pro)";
        }
    
        statsText.text = "Relationship with Matt: " + PlayerData.GetInstance().GetMattRelationship() + "/20 " + mattLevel 
        + "\nRelationship with Alex: " + PlayerData.GetInstance().GetAlexRelationship() + "/20 " + alexLevel + "\nAverage Viewers: " 
        + PlayerData.GetInstance().GetViewers() + " " + viewerLevel + "\nRhythmic Skill: " + PlayerData.GetInstance().GetRyhthmGameSkill() 
        + "/20 " + rhythmLevel + "\nPlatforming Skill: " + PlayerData.GetInstance().GetPlatformerGameSkill() + "/20 " + platformerLevel;
        if(statsScreen.activeInHierarchy == true)
        {
            statsScreen.SetActive(false);
        }
        else if(statsScreen.activeInHierarchy == false)
        {
            statsScreen.SetActive(true);
        }
    }
    /*
     * This method should be called when the game is finished
     * If the the minigame was started standalone, then it should bring it back to the hub.
     */
    public void LoadDialogueFromLastCharacter()
    {
        if (!(this.lastCharacter is null))
        {
            // if need to load dialgoue after the minigame
            ArrayList assetsToLoad = this.lastCharacter.GetResultAssets();
            SetToLoads((TextAsset)assetsToLoad[0], (Sprite)assetsToLoad[1], (Sprite)assetsToLoad[2]);
            //sceneChanger.FadeToScene(4);
            SceneManager.LoadScene("DialogueScene");
        }
        else
        {
            // don't load result dialogue, just go back to hub. 
            //Debug.Log(lastCharacter.ToString());
            //sceneChanger.FadeToScene(1);
            SceneManager.LoadScene("MainHub");
        }
    }

    public Character GetLastCharacter() 
    {
        return this.lastCharacter;
    }


    /**
     * Call this method when you only want to load the minigame, with no dialogue
     */
    public void StartRhythmMinigame()
    {
        // only load the minigame no dialogue needed.
        //this.minigameStarted = true;
       sceneChanger.FadeToScene(2); // change scene
    }

    public bool MinigameStarted() 
    {
        return this.minigameStarted;
    }
    
    public void StartDialogueDebug() {
        SetToLoads(inkJSON_DEBUG, portrait_DEBUG, backgroundImage_DEBUG);
        sceneChanger.FadeToScene(4);
    }

    private void SetToLoads(TextAsset ink, Sprite portrait, Sprite background)
    {
        this.inkToLoad = ink;
        this.portraitToLoad = portrait;
        this.backgroundImageToLoad = background;
    }

    public TextAsset GetInk()
    {
        return this.inkToLoad;
    }

    public Sprite GetPortrait()
    {
        return this.portraitToLoad;
    }

    public Sprite GetBackground()
    {
        return this.backgroundImageToLoad;
    }

    public void ToTitleScreenScene()
    {
        sceneChanger.FadeToScene(0);
    }

    public void ToMainHubScene()
    {
        sceneChanger.FadeToScene(1);
    }
}



