using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubManager : MonoBehaviour
{
    // Start is called before the first frame update


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


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoomOneButton()
    {
        // switch scenes
        // start the dialogue manager with passed in paramters
        Debug.Log(DialogueManager.GetInstance());
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON1_1, portrait1, backgroundImage1);

        SceneManager.LoadScene("DialogueScene");

    }

    public void RoomTwoButton() {
    
    }

}
