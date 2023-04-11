/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StreamManager : MonoBehaviour
{
    public int maxMessages = 25;

    public int viewerAverage;
    public int viewers;
    public int viewerIncrease;
    public int randNum;
    public int randViewer;

    public Text viewerText;
    //public Text viewerMood;
    //public Text viewerEngagement;

    public Button rhythmGameButton, speedParkourButton;
    //public GameManager rhythmGame;
    //public FinishCheck platformGame;
    public GameObject chatPanel, textObject, prompt, prompt2;

    public Text prompt2Text;
    public Text S;
    public Text A;
    public Text B;
    public Text C;
    public Text F;

    [SerializeField]
    List<Message> messageList = new List<Message>();
    

    // Start is called before the first frame update
    void Start()
    {
        S.text = "S";
        A.text = "A";
        B.text = "B";
        C.text = "C";
        F.text = "F";
        rhythmGameButton.enabled = false;
        speedParkourButton.enabled = false;
    }

    void ViewerCount() 
    {
        if(viewerAverage < viewerIncrease)
        {
            viewerAverage += 5;
        }
        if(viewerAverage < 50)
        {
            viewers = Random.Range(viewerAverage - 4, viewerAverage + 4);
        }
        else
        {
            viewers = Random.Range((int)System.Math.Floor(viewerAverage*0.9), (int)System.Math.Ceiling(viewerAverage*1.1));
        }
        viewerText.text = "Viewers: " + viewers;
        randNum = Random.Range(1, 11);
        randViewer = Random.Range(1, viewers);
        if(randNum == 1)
        {
            SendMessageToChat("Viewer_" + randViewer + ": Woo!!");
        }
        else if(randNum == 2)
        {
            SendMessageToChat("Viewer_" + randViewer + ": I love the stream :))");
        }
        else if(randNum == 3)
        {
            SendMessageToChat("Viewer_" + randViewer + ": ur doing awesome!");
        }
        else if(randNum == 4)
        {
            SendMessageToChat("Viewer_" + randViewer + ": W");
        }
        else if(randNum == 5)
        {
            SendMessageToChat("Viewer_" + randViewer + ": hahahaha xD");
        }
        else if(randNum == 6)
        {
            SendMessageToChat("Viewer_" + randViewer + ": this is da best streamer everrrr!");
        }
        else if(randNum == 7)
        {
            SendMessageToChat("Viewer_" + randViewer + ": lets GOOOO!");
        }
        else if(randNum == 8)
        {
            SendMessageToChat("Viewer_" + randViewer + ": yay!");
        }
        else if(randNum == 9)
        {
            SendMessageToChat("Viewer_" + randViewer + ": ʕ•́ᴥ•̀ʔっ♡");
        }
        else if(randNum == 10)
        {
            SendMessageToChat("Viewer_" + randViewer + ": ♡ ♥ ♡ ♥ ♡ ♥ ♡ ♥");
        }
    }

    /*public void Intro()
    {
        intro.gameObject.SetActive(false);
        viewerIncrease = viewerAverage + 50;
        viewerMood.text = "Viewer Mood: Excited!";
        viewerMood.color = Color.green;
        viewerEngagement.text = "Viewer Engangement: 8/10";
        viewerEngagement.color = Color.green;
    }
    *//*
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendMessageToChat(string text)
    {
        if(messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
        Message newMessage = new Message();
        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);
    }

    public void StartStream()
    {
        prompt.SetActive(false);
        rhythmGameButton.enabled = true;
        speedParkourButton.enabled = true;
        InvokeRepeating("ViewerCount", 2.0f, 0.8f);
        viewerAverage = 8;
    }
    
    public void PlayRhythm()
    {
        rhythmGameButton.enabled = false;
        if(GameManager.finalGradeText == S)
        {
            viewerIncrease = viewerAverage + 50;
            prompt2.SetActive(true);
            prompt2Text.text = "You played amazingly and the stream really loved it! You see a great improvement in viewers.";
        }
        if(GameManager.finalGradeText == A)
        {
            viewerIncrease = viewerAverage + 25;
            prompt2.SetActive(true);
            prompt2Text.text = "You played great and the stream was thrilled! You see a good improvement in viewers.";
        }
        if(GameManager.finalGradeText == B)
        {
            viewerIncrease = viewerAverage + 10;
            prompt2.SetActive(true);
            prompt2Text.text = "You played decently and the stream enjoyed it! You see an improvement in viewers.";
        }
        if(GameManager.finalGradeText == C)
        {
            viewerIncrease = viewerAverage + 5;
            prompt2.SetActive(true);
            prompt2Text.text = "You played fine and the stream was had fun! You see a slight improvement in viewers.";
        }
        if(GameManager.finalGradeText == F)
        {
            viewerIncrease = viewerAverage/2;
            prompt2.SetActive(true);
            prompt2Text.text = "You played poorly and the stream did not enjoy that! You see a small decline in viewers.";
        }
    }

    public void PlayPlatformer()
    {
        speedParkourButton.enabled = false;

        if(FinishCheck.gradeText == S)
        {
            viewerIncrease = viewerAverage + 50;
            prompt2.SetActive(true);
            prompt2Text.text = "You played amazingly and the stream really loved it! You see a great improvement in viewers.";
        }
        if(FinishCheck.gradeText == A)
        {
            viewerIncrease = viewerAverage + 25;
            prompt2.SetActive(true);
            prompt2Text.text = "You played great and the stream was thrilled! You see a good improvement in viewers.";
        }
        if(FinishCheck.gradeText == B)
        {
            viewerIncrease = viewerAverage + 10;
            prompt2.SetActive(true);
            prompt2Text.text = "You played decently and the stream enjoyed it! You see an improvement in viewers.";
        }
        if(FinishCheck.gradeText == C)
        {
            viewerIncrease = viewerAverage + 5;
            prompt2.SetActive(true);
            prompt2Text.text = "You played fine and the stream was had fun! You see a slight improvement in viewers.";
        }
        if(FinishCheck.gradeText == F)
        {
            viewerIncrease = viewerAverage/2;
            prompt2.SetActive(true);
            prompt2Text.text = "You played poorly and the stream did not enjoy that! You see a small decline in viewers.";
        }
    }

    public void prompt2Ok()
    {
        prompt2.SetActive(false);
    }
}

public class Message 
{
    public string text;
    public Text textObject;
}
*/