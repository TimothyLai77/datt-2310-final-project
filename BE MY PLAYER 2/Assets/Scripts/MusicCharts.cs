using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MusicCharts
{
    public static List<int> epicSongEasy = new List<int> { };

    public static List<int> epicSongNormal = new List<int> {
        //1, 1, 1, 1, //test line
        0, 0, 0, 1  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 1  ,

          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 1  ,

          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 1  ,

          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,

          0, 0, 0, 1  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 1  ,

          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 1  ,

          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 1  ,

          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,

          0, 0, 0, 1  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 1  ,

          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 1  ,

          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 1  ,

          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,

          0, 0, 0, 1  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 1  ,

          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 1, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 1  ,

          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 1  ,

          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          1, 0, 0, 0  ,
          0, 0, 1, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0  ,
          0, 0, 0, 0

    }; //import music sheet as list

    public static List<int> epicSongHard = new List<int> { };

}
