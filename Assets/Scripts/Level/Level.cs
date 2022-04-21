using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum LevelType
{
    normal, fast, gift
}
[Serializable]
public class Level 
{

    public Level(LevelType type,int levelNum,int[] chunkIndexs)
    {
        this.type = type;
        this.levelNum = levelNum;
        this.chunkIndexs = chunkIndexs; 
    }

    public LevelType type;
    public int levelNum;

    public int[] chunkIndexs;
}
