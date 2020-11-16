using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName ="NewLevel", menuName = "Create Level")]
public class Level : ScriptableObject
{
    public LevelType LevelType;
    public int CountWin;

    public void RandomizeLevel()
    {
        LevelType = (LevelType)Random.Range(1, (int)Enum.GetValues(typeof(LevelType)).Cast<LevelType>().Max()+1);
        CountWin = (int)(CountWin * Random.Range(0.8f, 1.2f));
    }
}

public enum LevelType
{
    Default,
    Asteroid,
    Time
}
