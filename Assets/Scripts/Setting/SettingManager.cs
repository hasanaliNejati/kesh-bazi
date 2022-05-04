using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{

    [SerializeField] private GameObject soundOn;
    [SerializeField] private GameObject soundOff;
    [SerializeField] private GameObject musicOn;
    [SerializeField] private GameObject musicOff;

    private void Start()
    {
        UpdateData();
    }

    public void MuteSound()
    {
        SaveManager.soundMute = !SaveManager.soundMute;
        UpdateData();
    }
    public void MuteMusic()
    {
        SaveManager.musicMute = !SaveManager.musicMute;
        UpdateData();
    }

    public void UpdateData()
    {
        soundOn.SetActive(!SaveManager.soundMute);
        soundOff.SetActive(SaveManager.soundMute);
        musicOn.SetActive(!SaveManager.musicMute);
        musicOff.SetActive(SaveManager.musicMute);
        var audios = FindObjectsOfType<AudioScript>();
        foreach (var item in audios)
        {
            item.SetSetting();
        }
    }
}
