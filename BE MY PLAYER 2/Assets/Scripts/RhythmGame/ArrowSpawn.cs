using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

//beatTempo in this script based on 150

public class ArrowSpawn : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject arrowPreFeb; //right arrow prefeb
    public GameObject leftArrowPrefeb;
    public GameObject upArrowPrefeb;
    public GameObject downArrowPrefeb;
    public Vector3 leftArrowSpawnPos;
    public Vector3 upArrowSpawnPos;
    public Vector3 downArrowSpawnPos;
    public Vector3 rightArrowSpawnPos;

    bool musicChartEndDebug = true;
    public bool hasStartedSpawn = false;
    public bool invokemusicChart = true;
    private bool spawnArrow = false;
    private int timeCounter;
    public float delaySheetBeforeStart = 0;

    int noteCurs = 0;
    int kindOfNotes = 1;

    //private static List<int> musicChart = MusicCharts.epicSongNormal;
    List<int> musicChart;
    public float beatTempo;
    private float beatCount = 0f;
    private int previousBeat = 0;

    private void Start()
    {
        timeCounter = 0;
        beatTempo = beatTempo / 60f;
        gameManager = GameManager.instance;
        //InvokeRepeating("SpawnMethod", 2, 1);
       
    }

    //public static void SetmusicChart(List<int> sheet)
    //{
    //    musicChart = sheet;
    //    RhythmGirlData.GetInstance().SetDifficulty(musicChart);
    //}

    void SpawnMethod()
    {
        Debug.Log(timeCounter);
        timeCounter++;
        spawnArrow = true;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.K))
        {

            GameObject newArrow = Instantiate(arrowPreFeb, leftArrowSpawnPos, Quaternion.Euler(0, 180, 0), transform);
        }*/
        /*int[] musicChart = new int[99999] {1,2,3,4};

        musicChart[1] = 12;
        print(musicChart[1]);*/

        if (gameManager.currentGameState == GameManager.GAME_STATE.SongPlaying)
        {
            if (gameManager.currentSongDifficulty == "Easy") {
                musicChart = gameManager.currentSelectedSong.easyChart;
                delaySheetBeforeStart = gameManager.currentSelectedSong.startDelay;
            
            }
            else if (gameManager.currentSongDifficulty == "Normal")
            {
                musicChart = gameManager.currentSelectedSong.normalChart;
                delaySheetBeforeStart = gameManager.currentSelectedSong.startDelay;
              
            }
            else if (gameManager.currentSongDifficulty == "Hard")
            {
                musicChart = gameManager.currentSelectedSong.hardChart;
                delaySheetBeforeStart = gameManager.currentSelectedSong.startDelay;
                
            }

            if (invokemusicChart)
            {
                SpawnMethod();
                invokemusicChart = false;
                Debug.Log(gameManager.currentSongDifficulty + " Chart Now Playing");
                Debug.Log("Delay: " + delaySheetBeforeStart);
                RhythmGirlData.GetInstance().SetDifficulty(gameManager.currentSongDifficulty);
            }

            if (spawnArrow)
            {
                beatCount += beatTempo * Time.deltaTime;

                if ((int)beatCount > previousBeat)
                {
                    //Debug.Log((int)beatCount); // if you want to display the beat counter
                    previousBeat = (int) beatCount;

                    if (musicChart.Count % 4 == 0) //check if last row is complete.
                    {
                        if (noteCurs < musicChart.Count) // check if sheet ends
                        {
                            //check this row first block(from left)
                            for (int i = 1; i <= kindOfNotes; i++)
                            {
                                if (musicChart[noteCurs] == i)
                                {
                                    GameObject LeftArrow = Instantiate(leftArrowPrefeb, leftArrowSpawnPos, Quaternion.Euler(0, 180, 0), transform);
                                }
                            }
                            noteCurs++;

                            //check this row second block
                            for (int i = 1; i <= kindOfNotes; i++)
                            {
                                if (musicChart[noteCurs] == i)
                                {
                                    GameObject UpArrow = Instantiate(upArrowPrefeb, upArrowSpawnPos, Quaternion.Euler(0, 0, 90), transform);
                                }
                            }
                            noteCurs++;

                            //check this row third block
                            for (int i = 1; i <= kindOfNotes; i++)
                            {
                                if (musicChart[noteCurs] == i)
                                {
                                    GameObject DownArrow = Instantiate(downArrowPrefeb, downArrowSpawnPos, Quaternion.Euler(0, 0, 270), transform);
                                }
                            }
                            noteCurs++;

                            //check this row forth block
                            for (int i = 1; i <= kindOfNotes; i++)
                            {
                                if (musicChart[noteCurs] == i)
                                {
                                    GameObject RightArrow = Instantiate(arrowPreFeb, rightArrowSpawnPos, Quaternion.Euler(0, 0, 0), transform);
                                }
                            }
                            noteCurs++;
                        }
                        else
                        {
                            if (musicChartEndDebug == true)
                            {
                                Debug.Log("Music sheet end.");
                                musicChartEndDebug = false;
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
}
