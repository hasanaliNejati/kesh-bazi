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
            return GetInt(levelCode);
        }
        set
        {
            SetInt(levelCode, value);
        }
    }
    #endregion

    #region candy
    const string candyCode = "candy code";
    public static int candy
    {
        get
        {
            return GetInt(candyCode, 0);
        }
        set
        {
            SetInt(candyCode, value);
        }
    }
    #endregion

    #region gem
    const string gemCode = "gem code";
    public static int gem
    {
        get
        {
            return GetInt(gemCode, 0);
        }
        set
        {
            SetInt(gemCode, value);
        }
    }
    #endregion

    #region selectedCharacter

    const string selectedCharacterCode = "selectedCharacter code";
    public static int selectedCharacter
    {
        get
        {
            return GetInt(selectedCharacterCode);
        }
        set
        {
            SetInt(selectedCharacterCode, value);
        }
    }
    #endregion

    #region boughtCharacter

    const string BouhgtCharacterCode = "boughtCharacter code";
    public static bool CheckBouhgtCharacter(int index)
    {
        if (index == 0)
            return true;
        return PlayerPrefs.GetInt(BouhgtCharacterCode + index) != 0;
    }
    public static void BuyCharacter(int index)
    {
        PlayerPrefs.SetInt(BouhgtCharacterCode + index, 1);
    }

    #endregion

    #region sound mute

    const string soundMuteCode = "soundSetting code";
    public static bool soundMute
    {
        get
        {
            return GetBool(soundMuteCode);
        }
        set
        {
            SetBool(soundMuteCode, value);
        }
    }

    #endregion

    #region music mute

    const string musicMuteCode = "music Setting code";
    public static bool musicMute
    {
        get
        {
            return GetBool(musicMuteCode);
        }
        set
        {
            SetBool(musicMuteCode,value);
        }
    }

    #endregion

    


    #region founctions
    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    public static int GetInt(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }
    public static float GetFloat(string key, float defaultValue = 0)
    {
        return PlayerPrefs.GetFloat(key, defaultValue);
    }

    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
    public static string GetString(string key, string defaultValue = "")
    {
        return PlayerPrefs.GetString(key, defaultValue);
    }

    //1 = true        0 = false
    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(musicMuteCode, value ? 1 : 0);
    }
    public static bool GetBool(string key, bool defaultValue = false)
    {
        return (PlayerPrefs.GetInt(musicMuteCode, defaultValue ? 1 : 0) != 0);
    }

    #endregion
}
