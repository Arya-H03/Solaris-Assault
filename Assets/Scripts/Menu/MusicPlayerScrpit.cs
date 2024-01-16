using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerScrpit : MonoBehaviour
{
    public AudioSource MainAudiSource;
    public AudioSource SpecialfxVolume;
  
    // Start is called before the first frame update
    void Start()
    {
        MainAudiSource.Play();
        SpecialfxVolume.Play();

       
    }

    // Update is called once per frame
    void Update()
    {
       
        MainAudiSource.volume = MainMenu.saveData.mainmusicvolume;
        SpecialfxVolume.volume = MainMenu.saveData.specialfx;
    }
    //Main Volume Function
    public void UpdateMainVolume(float volume)
    {
        MainMenu.saveData.mainmusicvolume = volume;
    }
    //Special fx Function
    public void UpdateSpecialFXVolume(float volume)
    {
        MainMenu.saveData.specialfx = volume;
    }
}
