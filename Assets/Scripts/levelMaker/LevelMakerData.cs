using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level maker data", menuName = "ScriptableObjects/LevelMaker data", order = 1)]
public class LevelMakerData : ScriptableObject
{
    public int levelNum = 200;
    public int fasterLevel = 10;
    public int hardLevelOffset = 3;
    public int levelChunkNumber = 10;
    public int levelChunkNumberOffset = 3;
}
