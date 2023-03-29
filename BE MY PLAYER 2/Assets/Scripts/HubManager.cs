using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubManager : MonoBehaviour
{

    [Header("FOR DEBUG AND TESTING DIALOGUE")]
    [SerializeField] public TextAsset inkJSON_DEBUG;
    [SerializeField] public Sprite portrait_DEBUG;
    [SerializeField] public Sprite backgroundImage_DEBUG;

    private static HubManager instance;

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
        SceneManager.LoadScene("DialogueScene"); // swithc to dialogue
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
            SceneManager.LoadScene("DialogueScene");
        }
        else
        {
            // don't load result dialogue, just go back to hub. 
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

    public void StartDialogueDebug() {
        SetToLoads(inkJSON_DEBUG, portrait_DEBUG, backgroundImage_DEBUG);
        SceneManager.LoadScene("DialogueScene");
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



