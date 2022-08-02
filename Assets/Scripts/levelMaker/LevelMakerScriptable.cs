using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level maker", menuName = "ScriptableObjects/LevelMaker", order = 1)]
public class LevelMakerScriptable : ScriptableObject
{
    public int minLevel = 0;
    public int maxLevel = 20;
    public int fasterLevel = 10;
    public int levelChunkNumber = 5;
    public int levelChunkNumberOffset = 3;
    public ChunksList chunkList;
}
