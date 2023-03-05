using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;


// Tutorial followed: https://www.youtube.com/watch?v=vY0Sk93YUhA


public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject buttonPanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject portraitArea;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    
    
    private Story currentStory;
    private bool dialogueIsPlaying;
    private Sprite portraitSprite; // idk if this should be game object
    private static DialogueManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        portraitArea.SetActive(false);
        // init choices 
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }
        // hard coded with space for now, might wanna change to unity input manager
        if (Input.GetKeyDown("space") && currentStory.currentChoices.Count == 0)
        {
            ContinueStory();
        }
    }

  

    // method to enter the dialgoue mode, needs the ink JSON file + that person's portrait
    public void EnterDialogueMode(TextAsset inkJSON, Texture2D portrait)
    {
        currentStory = new Story(inkJSON.text);
        //portraitImage.GetComponent<Image>().sprite = portrait; // load sprite passed in
        //maybe: https://forum.unity.com/threads/generating-sprites-dynamically-from-png-or-jpeg-files-in-c.343735/
        portraitSprite = Sprite.Create(portrait, new Rect(0, 0, portrait.width, portrait.height), new Vector2(0, 0), 100.0f);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        buttonPanel.SetActive(false);
        //portraitSprite. = true; // reveal the user portrait
        portraitArea.SetActive(true);


        ContinueStory();

       
    }


    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        buttonPanel.SetActive(false); // for now as false, might wanna flip later
        //portraitSprite.enabled = false; // hide the portrait
        portraitArea.SetActive(false);
    }


    private void ContinueStory()
    {

        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("UI can't support these many choices");
        }

        int index = 0;
        // init choices 
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        // make any overflowed choices invisiible
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        //StartCoroutine(SelectFirstChoice());
    }


    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }



}
