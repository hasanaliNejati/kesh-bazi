using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{



    #region level
    const string levelCode = "level code";
    public static int level
    {
        get
        {
            return PlayerPrefs.GetInt(levelCode);
        }
        set
        {
            PlayerPrefs.SetInt(levelCode, value);
        }
    }
    #endregion

    #region candy
    const string candyCode = "candy code";
    public static int candy
    {
        get
        {
            return PlayerPrefs.GetInt(candyCode);
        }
        set
        {
            PlayerPrefs.SetInt(candyCode, value);
        }
    }
    #endregion

    #region gem
    const string gemCode = "gem code";
    public static int gem
    {
        get
        {
            return PlayerPrefs.GetInt(gemCode);
        }
        set
        {
            PlayerPrefs.SetInt(gemCode, value);
        }
    }
    #endregion


}
