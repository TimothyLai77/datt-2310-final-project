using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Character
{
    //public abstract ArrayList GetAssets();

    public abstract ArrayList GetStartingAssets();

    public abstract ArrayList GetResultAssets();

    public abstract void SetLastPlayerScore(int score);
}
