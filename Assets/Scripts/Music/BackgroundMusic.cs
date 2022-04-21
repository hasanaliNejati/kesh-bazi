using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public List<AudioClip> audios;
    [SerializeField] private AudioSource audioSource;
    //LOGIC 

    private int beforIndex;
    private int audioIndex;

    private void Awake()
    {
        if (FindObjectsOfType<BackgroundMusic>().Length > 1)
        {

            Destroy(gameObject);
        }
        else
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audios[audioIndex];
        audioSource.Play();
    }

    public void ChangeAudio(int index)
    {
        beforIndex = audioIndex;
        audioIndex = index;

    }
    private void Update()
    {

        if(beforIndex != audioIndex)
        {
            if(audioSource.pitch != 0)
            {
                audioSource.pitch = Mathf.MoveTowards(audioSource.pitch, 0, Time.deltaTime);

            }
            else
            {
                beforIndex = audioIndex;
                audioSource.clip = audios[audioIndex];
                audioSource.Play();

            }
        }else if(audioSource.pitch != 1)
        {
            audioSource.pitch = Mathf.MoveTowards(audioSource.pitch, 1, Time.deltaTime);
        }
    }
}
