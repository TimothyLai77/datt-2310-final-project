using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.ComponentModel.Design;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;

    [Header("Timer Settings")]
    public float currentTime;


    public bool countingTime;
    public bool levelFinished;
    public GameObject player;
    public int totalNumColl;
    private float playerSpeed;
    public int speedLevel;
    public bool scorePanelB;
    public GameObject scorePanel;
    public Button SPcloseButton;
    public GameObject start;
    public bool finished;


    public GameObject finish;
    public static Timer instance;

    //Collecting System
    public int appleNum;

    //score up animation
    public float animationDuration = 3f;

    //highest Score
    public int levelNum;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        appleNum = 0;
        playerSpeed = player.GetComponent<PlatformerPlayerMovement>().speed;
        countingTime = false;
        scorePanelB = false;
        speedLevel = 0;

        //scorepanel default hide
        scorePanel.SetActive(false);
        scoreText.enabled = false;
        scoreText2.enabled = false;
        SPcloseButton.gameObject.SetActive(false);
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        //old code
        /*FinishCheck finishCheck = finish.GetComponent<FinishCheck>();
        //Debug.Log(finishCheck.levelFinished);
        if (!finishCheck.levelFinished)
        {
            if (countingTime)
            {
                timerText.enabled = true;
                currentTime += Time.deltaTime;
            }
            else
            {
                timerText.enabled = false;
                currentTime = 0;
            }

            string speedLevelT = "";
            if (speedLevel == 0)
            {
                speedLevelT = "Default";
            } else
            {
                speedLevelT = speedLevel.ToString();
            }
            timerText.text = "Time: " + currentTime.ToString("0.000") + "\nSpeed: " + speedLevelT;

            finishCheck.setScores(0, 999999999);
        }
        else
        {
            finishCheck.setScores(appleNum, currentTime);
        }*/
        
        if (countingTime)
        {
            timerText.enabled = true;
            currentTime += Time.deltaTime;
        }
        else// if (!countingTime)
        {
            timerText.enabled = false;
        }

        string speedLevelT = "";
        if (speedLevel == 0)
        {
            speedLevelT = "Default";
        }
        else
        {
            speedLevelT = speedLevel.ToString();
        }
        timerText.text = "Time: " + currentTime.ToString("0.000") + "\nSpeed: " + speedLevelT + "\nCollection: " + appleNum;

        if (scorePanelB)
        {
            scorePanel.SetActive(true);
            scoreText.enabled = true;
            scoreText2.enabled = true;
            SPcloseButton.gameObject.SetActive(true);
            if (finished)
            {
                StartCoroutine(AnimateNumber());
                StartCoroutine(AnimateCollection());
                Debug.Log("level one finished");
                Debug.Log(currentTime);
                Debug.Log(appleNum);
                FinishCheck finishCheck = finish.GetComponent<FinishCheck>();
                finishCheck.setScoresLevelOne(appleNum, currentTime);
            } else
            {
                scoreText.text = "Level: " + levelNum + "\n\nNot Complete";
            }
            
        } else
        {
            scorePanel.SetActive(false);
            scoreText.enabled = false;
            scoreText2.enabled = false;
            SPcloseButton.gameObject.SetActive(false);
        }

        //exit
        if (Input.GetKey(KeyCode.Escape))
        {
            player.transform.position = new Vector3(-56.75f, -13.37f, 0f);
            start.transform.position = new Vector3(-56.75f, -13.37f, 0f);
            countingTime = false;
            scorePanelB = true;
        }
    }

    public void AppleCollect()
    {
        appleNum++;
        if (speedLevel < 5)
        {
            playerSpeed *= 1.067f;
            speedLevel ++;
        }
        player.GetComponent<PlatformerPlayerMovement>().speed = playerSpeed;
        Debug.Log("Apple you got:" + appleNum); //test
        Debug.Log("CurrentSpeed:" +  playerSpeed); //test
    }

    private IEnumerator AnimateNumber()
    {
        float elapsedTime = 0f;
        float currentValue = 0;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            currentValue = Mathf.Lerp(0, currentTime, elapsedTime / animationDuration);
            scoreText.text = "Level: " + levelNum + "\n\nTime: " + currentValue.ToString();
            yield return null;
        }

        // Ensure the final value is the target value
        scoreText.text = "Level: " + levelNum + "\n\nTime: " + currentTime.ToString();
    }

    private IEnumerator AnimateCollection()
    {
        float elapsedTime = 0f;
        float currentCollValue = 0;
        

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            currentCollValue = Mathf.Lerp(0, appleNum, elapsedTime / animationDuration);
            scoreText2.text = "Collection: " + currentCollValue.ToString();
            yield return null;
        }

        // Ensure the final value is the target value
        scoreText2.text = "Collection: " + appleNum.ToString();
    }


    public void closeScorePanel()
    {
        scorePanelB = false;
        //Debug.Log("closepannel");
    }

    public void openScorePanel()
    {
        scorePanelB = true;
        //Debug.Log("closepannel");
    }
}
