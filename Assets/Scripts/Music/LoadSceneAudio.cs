using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LoadSceneAudio : MonoBehaviour
{
    

    public void Play()
    {
        var audio = GetComponent<AudioSource>();
        audio.Play();
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
        Destroy(gameObject, audio.clip.length);
    }
}
