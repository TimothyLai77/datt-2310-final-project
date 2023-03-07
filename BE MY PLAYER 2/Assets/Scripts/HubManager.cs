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
    [SerializeField] private static TextAsset inkJSON1_1; // this is just pain...
    [SerializeField] private static Sprite portrait1;
    [SerializeField] private static Sprite backgroundImage1;

    [Header("Person 2")]
    [SerializeField] private static TextAsset inkJSON1_2; // this is just pain...
    [SerializeField] private static Sprite portrait2;
    [SerializeField] private static Sprite backgroundImage2;


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
        //SceneManager.LoadScene("Dialogue");
        Debug.Log("button 1 was pressed");
    }

    public void RoomTwoButton() {
        Debug.Log("button 2 was pressed");
    }

}
