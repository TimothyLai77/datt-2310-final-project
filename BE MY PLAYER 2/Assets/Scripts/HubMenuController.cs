using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubMenuController : MonoBehaviour
{
    // Start is called before the first frame update



    [Header("Ink JSON 1")]
    [SerializeField] private TextAsset inkJSON1;

    [Header("Ink JSON 2")]
    [SerializeField] private TextAsset inkJSON2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void personOne() 
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON1);
    }

    public void personTwo()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON2);
    }
}
