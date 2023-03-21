using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubMenuController : MonoBehaviour
{
    // Start is called before the first frame update



    [Header("Person 1")]
    [SerializeField] private TextAsset inkJSON1;
    [SerializeField] private Sprite portrait1;
    [SerializeField] private Sprite backgroundImage1;

    [Header("Person 2")]
    [SerializeField] private TextAsset inkJSON2;
    [SerializeField] private Sprite portrait2;
    [SerializeField] private Sprite backgroundImage2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PersonOne() 
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON1, portrait1, backgroundImage1);
    }

    public void PersonTwo()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON2, portrait2, backgroundImage2);
    }
}
