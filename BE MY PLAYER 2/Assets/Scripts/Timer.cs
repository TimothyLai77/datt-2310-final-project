using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;


    public bool countDown;
    public bool levelFinished;

    public GameObject finish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FinishCheck finishCheck = finish.GetComponent<FinishCheck>();
        //Debug.Log(finishCheck.levelFinished);
        if (!finishCheck.levelFinished)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
            timerText.text = currentTime.ToString("0.000");
        }
    }
}
