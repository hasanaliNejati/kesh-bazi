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
            return PlayerPrefs.GetInt(candyCode,0);
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
            return PlayerPrefs.GetInt(gemCode,0);
        }
        set
        {
            PlayerPrefs.SetInt(gemCode, value);
        }
    }
    #endregion

    #region selectedCharacter

    const string selectedCharacterCode = "selectedCharacter code";
    public static int selectedCharacter
    {
        get
        {
            return PlayerPrefs.GetInt(selectedCharacterCode);
        }
        set
        {
            PlayerPrefs.SetInt(selectedCharacterCode, value);
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
            return (PlayerPrefs.GetInt(soundMuteCode) != 0);
        }
        set
        {
            PlayerPrefs.SetInt(soundMuteCode, value ? 1 : 0);
        }
    }

    #endregion

    #region music mute

    const string musicMuteCode = "music Setting code";
    public static bool musicMute
    {
        get
        {
            return (PlayerPrefs.GetInt(musicMuteCode) != 0);
        }
        set
        {
            PlayerPrefs.SetInt(musicMuteCode, value ? 1 : 0);
        }
    }

    #endregion
}
