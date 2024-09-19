using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    public AudioClip backgroundMusic;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = backgroundMusic;
        Invoke("PlayDelayedBGM", 2.5f); 
    }

    void PlayDelayedBGM()
    {
        // 배경 음악 재생
        audioSource.volume = 1;
        audioSource.Play();
    }
}
