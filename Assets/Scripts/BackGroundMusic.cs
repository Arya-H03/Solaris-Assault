using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    public AudioClip[] audioClips;
    private int currentTrack = 0;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[currentTrack];
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            currentTrack++;
            if (currentTrack >= audioClips.Length)
            {
                currentTrack = 0;
            }
            audioSource.clip = audioClips[currentTrack];
            audioSource.Play();
        }
    }
}
