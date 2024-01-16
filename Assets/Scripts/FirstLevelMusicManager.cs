using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class FirstLevelMusicManager : MonoBehaviour
{
    public static SaveData saveDataLevelOne;
    public AudioClip explosion;
    public AudioClip hit;
    public AudioClip shield;
    public AudioClip shoot;
    public AudioClip dash;
    public AudioClip pew;

    public static bool IsEnemyDeath;
    public static bool IsShieldActive;
    public static bool IsEnemyHit;
    public static bool IsDashing;
    public static bool IsShooting;
    public static bool IsPew;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (IsEnemyDeath == true)
        {
            //explosion.Play();
            IsEnemyDeath = false;
        }
    }
    //Main Volume Function
    public void UpdateMainVolume(float volume)
    {
        saveDataLevelOne.mainmusicvolume = volume;
    }
    //Special fx Function

}
