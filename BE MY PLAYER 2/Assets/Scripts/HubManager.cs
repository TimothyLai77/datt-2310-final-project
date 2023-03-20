using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubManager : MonoBehaviour
{


    private static HubManager instance;
    private RhythmGirlData rhythmGDataInstance;

    private bool minigameStarted;

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
    }


    void Start()
    {
        //this.minigameStarted = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoomOneButton()
    {
        this.lastCharacter = RhythmGirlData.GetInstance();
        Debug.Log(this.lastCharacter.ToString());
        ArrayList assetsToLoad = (this.lastCharacter).GetAssets();
        //Debug.Log(this.LastCharacter.ToString());
        SetToLoads((TextAsset)assetsToLoad[0],(Sprite) assetsToLoad[1], (Sprite)assetsToLoad[2]);
        //this.minigameStarted = false; // want to load the dialogue scene after the game
        //LoadDialogueFromLastCharacter();
        SceneManager.LoadScene("DialogueScene");
    }

    public void LoadDialogueFromLastCharacter()
    {
        if (!(this.lastCharacter is null))
        {

            ArrayList assetsToLoad = this.lastCharacter.GetAssets();
            SetToLoads((TextAsset)assetsToLoad[0], (Sprite)assetsToLoad[1], (Sprite)assetsToLoad[2]);
            SceneManager.LoadScene("DialogueScene");
        }
        else
        {
            //Debug.Log("b u g");
            Debug.Log(lastCharacter.ToString());
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
        SceneManager.LoadScene("RhythmGame"); // change scene
    }

    public bool MinigameStarted() 
    {
        return this.minigameStarted;
    }

    public void RoomTwoButton() {
    
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
        SceneManager.LoadScene("TitleScreen");
    }

    public void ToMainHubScene()
    {
        SceneManager.LoadScene("MainHub");
    }
}



