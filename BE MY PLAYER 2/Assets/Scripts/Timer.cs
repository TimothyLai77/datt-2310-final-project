using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    [Header("Timer Settings")]
    public float currentTime;


    public bool countingTime;
    public bool levelFinished;
    public GameObject player;
    public int totalNumColl;
    private float playerSpeed;
    private int speedLevel;
    public bool scorePanelB;
    public GameObject scorePanel;
    public int levelNum;


    public GameObject finish;
    public static Timer instance;

    //Collecting System
    public int appleNum;

    //score up animation
    public float animationDuration = 3f;
    public TMP_Text textMeshPro;




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
        timerText.text = "Time: " + currentTime.ToString("0.000") + "\nSpeed: " + speedLevelT;

        if (scorePanelB)
        {
            scorePanel.SetActive(true);
            scoreText.enabled=true;
            StartCoroutine(AnimateNumber());
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
            scoreText.text = currentValue.ToString();
            yield return null;
        }

        // Ensure the final value is the target value
        scoreText.text = "Time: " + currentTime.ToString();
    }

}
