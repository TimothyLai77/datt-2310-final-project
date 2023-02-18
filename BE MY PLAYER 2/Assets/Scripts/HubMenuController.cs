using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubMenuController : MonoBehaviour
{
    // Start is called before the first frame update



    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void personOne() 
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
}
