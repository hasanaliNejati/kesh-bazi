using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioScript : MonoBehaviour
{
    [SerializeField] private bool isBackgroudMusic;

    private void OnEnable()
    {
        SetSetting();
    }

    public void SetSetting()
    {
        if (isBackgroudMusic)
            GetComponent<AudioSource>().mute = SaveManager.musicMute;
        else
            GetComponent<AudioSource>().mute = SaveManager.soundMute;
    }
}
