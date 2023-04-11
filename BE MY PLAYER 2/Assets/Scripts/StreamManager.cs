using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StreamManager : MonoBehaviour
{
    private static StreamManager instance;
    public GameObject streamScreen, chatPanel, textObject;
    public SceneChanger sceneChanger;
    public SoundFX soundfx;

    public int maxMessages = 25;
    public int textOption;
    public int viewers, viewerAverage, viewerIncrease, randNum, randViewer;
    public static bool streamed = false;
    public Text viewerText, dialogueText;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    void Start() 
    {

    }

    void Update()
    {
        viewerAverage = PlayerData.GetInstance().GetViewers();
        if(viewerAverage <= 5)
        {
            PlayerData.GetInstance().SetViewers(5);
            viewerAverage = PlayerData.GetInstance().GetViewers();
        }
        if(streamed == true)
        {
            streamed = false;
            sceneChanger.FadeOut();
            if(RhythmGirlData.instance.GetStreamResult() == "RESULT_GOOD" || PlatformerGuyData.GetInstance().GetStreamResult() == "RESULT_GOOD")
            {
                RhythmGirlData.instance.SetStreamResult("");
                textOption = 1;
                PlayerData.GetInstance().SetIncrease(25);
                viewerIncrease = PlayerData.GetInstance().GetViewers();
            }
            else if(RhythmGirlData.instance.GetStreamResult() == "RESULT_OKAY" || PlatformerGuyData.GetInstance().GetStreamResult() == "RESULT_OKAY")
            {
                RhythmGirlData.instance.SetStreamResult("");
                textOption = 2;
                PlayerData.GetInstance().SetIncrease(10);
                viewerIncrease = PlayerData.GetInstance().GetViewers();
            }
            else if(RhythmGirlData.instance.GetStreamResult() == "RESULT_BAD" || PlatformerGuyData.GetInstance().GetStreamResult() == "RESULT_BAD")
            {
                RhythmGirlData.instance.SetStreamResult("");
                textOption = 3;
                PlayerData.GetInstance().SetIncrease(-10);
                viewerIncrease = PlayerData.GetInstance().GetViewers();
            }
            InvokeRepeating("Stream", 1.0f, 0.8f);
            Invoke("EndStream", 10f);
        }
    }
    
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
    }

    public void StartRhythmGame() 
    {
        GameManager.streamOrRelation = true;
        sceneChanger.FadeToScene(2);
    }

    public void StartPlatformerGame()
    {
       FinishCheck.streamOrRelation = true;
       sceneChanger.FadeToScene(3);
    }

    void Stream()
    {
        if(textOption == 1)
        {
            dialogueText.text = "You played amazingly and the stream really loved it! You see a great improvement in viewers.";
        }
        else if(textOption == 2)
        {
            dialogueText.text = "You played fine and the stream had fun! You see a slight improvement in viewers.";
        }
        else if(textOption == 3)
        {
            dialogueText.text = "You played poorly and the stream did not enjoy that! You see a small decline in viewers.";
        }
        streamScreen.SetActive(true);
        if(viewerAverage < viewerIncrease)
        {
            viewerAverage += 5;
        }
        if(viewerAverage > viewerIncrease)
        {
            viewerAverage -= 5;
        }
        if(viewerAverage < 50)
        {
            viewers = Random.Range(viewerAverage - 4, viewerAverage + 4);
            if(viewers <= 0)
            {
                viewers += 4;
            }
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
        soundfx.ChatSound();
    }

    void EndStream()
    {
        streamScreen.SetActive(false);
        CancelInvoke("Stream");
        sceneChanger.FadeIn();
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

    public class Message 
    {
        public string text;
        public Text textObject;
    }

    public void ReturnToHub()
    {
        sceneChanger.FadeToScene(1);
    }


    public static StreamManager GetInstance()
    {
        return instance;
    }
}