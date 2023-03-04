using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public GameObject arrowPreFeb;
    public Vector3 leftArrowSpawnPos;
    public Vector3 upArrowSpawnPos;
    public Vector3 downArrowSpawnPos;
    public Vector3 rightArrowSpawnPos;
    bool musicSheetEndDebug = true;
    int noteCurs = 0;
    int kindOfNotes = 1;
    List<int> musicSheet = new List<int> { 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0 }; //import music sheet as list

    public float beatTempo;
    private float beatCount = 0f;
    private int previousBeat = 0;

    private void Start()
    {
        beatTempo = beatTempo / 60f;
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
                    for (int i = 0; i <= kindOfNotes; i++)
                    {
                        if (musicSheet[noteCurs] == 1)
                        {
                            GameObject newArrow = Instantiate(arrowPreFeb, leftArrowSpawnPos, Quaternion.Euler(0, 180, 0), transform);
                        }
                    }
                    noteCurs++;

                    //check this row second block
                    for (int i = 0; i <= kindOfNotes; i++)
                    {
                        if (musicSheet[noteCurs] == 1)
                        {
                            GameObject newArrow = Instantiate(arrowPreFeb, upArrowSpawnPos, Quaternion.Euler(0, 90, 0), transform);
                        }
                    }
                    noteCurs++;

                    //check this row third block
                    for (int i = 0; i <= kindOfNotes; i++)
                    {
                        if (musicSheet[noteCurs] == 1)
                        {
                            GameObject newArrow = Instantiate(arrowPreFeb, downArrowSpawnPos, Quaternion.Euler(0, 270, 0), transform);
                        }
                    }
                    noteCurs++;

                    //check this row forth block
                    for (int i = 0; i <= kindOfNotes; i++)
                    {
                        if (musicSheet[noteCurs] == 1)
                        {
                            GameObject newArrow = Instantiate(arrowPreFeb, rightArrowSpawnPos, Quaternion.Euler(0, 0, 0), transform);
                        }
                    }
                    noteCurs++;
                } else
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
