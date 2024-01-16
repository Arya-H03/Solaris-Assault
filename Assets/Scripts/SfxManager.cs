using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource src;
    public AudioClip enemydead, enemyhit, shield,playerHit;

    // Update is called once per frame
    public void PlayEnemyDead()
    {
        src.clip= enemydead;
        src.Play();
    }

    public void PlayEnemyHit()
    {
        src.clip = enemyhit;
        src.Play();
    }

    public void PlayShield()
    {
        src.clip = shield;
        src.Play();
    }

    public void PlayerHit()
    {
        src.clip = playerHit;
        src.Play();
    }
}
