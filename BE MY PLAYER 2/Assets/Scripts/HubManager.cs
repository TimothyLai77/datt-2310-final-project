using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubManager : MonoBehaviour
{

    // for now just hard load the assets but ideally it should be kinad dynamic based
    // on the state of the game like relationships -> differnet texts

    // static types should help with loading across scenes
    // https://stackoverflow.com/questions/32306704/how-to-pass-data-and-references-between-scenes-in-unity
                
    [Header("Person 1")]
    [SerializeField] public TextAsset inkJSON1_1; // this is just pain...
    [SerializeField] public Sprite portrait1;
    [SerializeField] public Sprite backgroundImage1;

    [Header("Person 2")]
    [SerializeField] public TextAsset inkJSON1_2; // this is just pain...
    [SerializeField] public Sprite portrait2;
    [SerializeField] public Sprite backgroundImage2;

    public static HubManager instance;


    // not super clean but set these when the button is pressed
    private TextAsset inkToLoad; // this is just pain...
    private Sprite portraitToLoad;
    private Sprite backgroundImageToLoad;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoomOneButton()
    {
        // set what to laod then load the scene
        inkToLoad = inkJSON1_1;
        portraitToLoad = portrait1;
        backgroundImageToLoad = backgroundImage1;
        SceneManager.LoadScene("DialogueScene");
    }

    public void RoomTwoButton() {
    
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



