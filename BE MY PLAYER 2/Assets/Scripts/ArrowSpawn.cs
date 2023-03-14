using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

//beatTempo in this script based on 150

public class ArrowSpawn : MonoBehaviour
{
    public GameObject arrowPreFeb; //right arrow prefeb
    public GameObject leftArrowPrefeb;
    public GameObject upArrowPrefeb;
    public GameObject downArrowPrefeb;
    public Vector3 leftArrowSpawnPos;
    public Vector3 upArrowSpawnPos;
    public Vector3 downArrowSpawnPos;
    public Vector3 rightArrowSpawnPos;
    bool musicSheetEndDebug = true;
    public bool hasStartedSpawn = false;
    public bool invokeMusicSheet = true;
    private bool spawnArrow = false;
    private int timeCounter;
    public float delaySheetBeforeStart = 0;
    int noteCurs = 0;
    int kindOfNotes = 1;

    List<int> musicSheet = MusicCharts.epicSongHard;

    public float beatTempo;
    private float beatCount = 0f;
    private int previousBeat = 0;

    private void Start()
    {
        timeCounter = 0;
        beatTempo = beatTempo / 60f;
        //InvokeRepeating("SpawnMethod", 2, 1);
    }

    void SpawnMethod()
    {
        Debug.Log(timeCounter);
        timeCounter++;
        spawnArrow = true;
        
    }


    private void invoke()
    {
        Debug.Log("invoke");
        Invoke("SpawnMethod", delaySheetBeforeStart);
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.K))
        {

            GameObject newArrow = Instantiate(arrowPreFeb, leftArrowSpawnPos, Quaternion.Euler(0, 180, 0), transform);
        }*/
        /*int[] musicSheet = new int[99999] {1,2,3,4};

        musicSheet[1] = 12;
        print(musicSheet[1]);*/

        

        if (!hasStartedSpawn)
        {
            if (Input.anyKeyDown)
            {
                hasStartedSpawn = true;
                Debug.Log("hasStartedSpawn");
            }
        }
        else
        {
            if (invokeMusicSheet)
            { 
                invoke();
                Debug.Log("firstinvoke");
                invokeMusicSheet = false;
            }
            
        }
        if (spawnArrow)
        {
            beatCount += beatTempo * Time.deltaTime;

            if ((int)beatCount > previousBeat)
            {
                //Debug.Log((int)beatCount); // if you want to display the beat counter
                previousBeat = (int)beatCount;

                if (musicSheet.Count % 4 == 0) //check if last row is complete.
                {
                    if (noteCurs < musicSheet.Count) // check if sheet ends
                    {
                        //check this row first block(from left)
                        for (int i = 1; i <= kindOfNotes; i++)
                        {
                            if (musicSheet[noteCurs] == i)
                            {
                                GameObject LeftArrow = Instantiate(leftArrowPrefeb, leftArrowSpawnPos, Quaternion.Euler(0, 180, 0), transform);
                            }
                        }
                        noteCurs++;

                        //check this row second block
                        for (int i = 1; i <= kindOfNotes; i++)
                        {
                            if (musicSheet[noteCurs] == i)
                            {
                                GameObject UpArrow = Instantiate(upArrowPrefeb, upArrowSpawnPos, Quaternion.Euler(0, 0, 90), transform);
                            }
                        }
                        noteCurs++;

                        //check this row third block
                        for (int i = 1; i <= kindOfNotes; i++)
                        {
                            if (musicSheet[noteCurs] == i)
                            {
                                GameObject DownArrow = Instantiate(downArrowPrefeb, downArrowSpawnPos, Quaternion.Euler(0, 0, 270), transform);
                            }
                        }
                        noteCurs++;

                        //check this row forth block
                        for (int i = 1; i <= kindOfNotes; i++)
                        {
                            if (musicSheet[noteCurs] == i)
                            {
                                GameObject RightArrow = Instantiate(arrowPreFeb, rightArrowSpawnPos, Quaternion.Euler(0, 0, 0), transform);
                            }
                        }
                        noteCurs++;
                    }
                    else
                    {
                        if (musicSheetEndDebug == true)
                        {
                            Debug.Log("Music sheet end.");
                            musicSheetEndDebug = false;
                        }
                    }
                }
                else
                {

                    Debug.Log("Sheet's last row not complete.");

                }
            }
        }
    }
}
