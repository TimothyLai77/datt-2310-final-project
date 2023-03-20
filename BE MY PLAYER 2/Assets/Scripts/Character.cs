using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Character
{
    public abstract ArrayList GetAssets();

    public abstract void SetLastPlayerScore(int score);
}
