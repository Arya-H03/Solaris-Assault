using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip enemydead, enemyhit, shield;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayEnemyDead()
    {
        audioSource.PlayOneShot(enemydead);
    }

    public void PlayEnemyHit()
    {
        audioSource.PlayOneShot(enemyhit);
    }

    public void PlayShield()
    {
        audioSource.PlayOneShot(shield);
    }
}
