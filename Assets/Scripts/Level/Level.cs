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

    public Level(LevelType type,int[] chunkIndexs)
    {
        this.type = type;
        this.chunkIndexs = chunkIndexs; 
    }

    public LevelType type;
    public int[] chunkIndexs;
}
