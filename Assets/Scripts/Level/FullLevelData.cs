using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class FullLevelData
{

    public FullLevelData(Level[] levels)
    {
        this.levels = levels;
    }
    public Level[] levels;
}
