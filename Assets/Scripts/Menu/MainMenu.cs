using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static SaveData saveData;
    [SerializeField] GameObject StartCanvas;
    [SerializeField] GameObject SettingCanvas;
    [SerializeField] GameObject ExitCanvas;

    [SerializeField] GameObject tutorialCanvas;
    [SerializeField] GameObject LivesCanvas;
    [SerializeField] GameObject ShieldCanvas;
    [SerializeField] GameObject HealthCanvas;
    [SerializeField] GameObject HeatCanvas;
    [SerializeField] GameObject AbilitiesCanvas;
    int id;
    //
    //Save Path
    string SavePath => Path.Combine(Application.persistentDataPath, "save.data");
    //
    //Creating Save File if not created

    private void Awake()
    {
        if (saveData == null)
            Load();
        else
        {
            Save();
        }



    }
    //private void Awake()
    //{
    //    if (saveData == null)
    //        Load();
    //    else
    //        Save();
    //    //if (!saveData.lvl2)
    //    //{ saveData.lvl2 = false; }
    //    //if (!saveData.lvl3)
    //    //{ saveData.lvl3 = false; }
    //    //if (!saveData.lvl4)
    //    //{ saveData.lvl4 = false; }
    //    //if (saveData.lvl5)
    //    //{ saveData.lvl5 = false; }
    //    //foreach (var skilllistsave in saveData.skillLevels)
    //    //{
    //    //    saveData.skillLevels[id] = SkillTree.skilltree.SkillLevels[id];
    //    //    id++;
    //    //}

    //}
    //
    //Load Function
    void Load()
    {
        FileStream file = null;
        try
        {
            file = File.Open(SavePath, FileMode.Open);
            var bf = new BinaryFormatter();
            saveData = bf.Deserialize(file) as SaveData;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            saveData = new SaveData();
        }
        finally
        {
            if (file != null)
                file.Close();
        }
    }
    //
    //Save Function
    void Save()
    {
        FileStream file = null;
        try
        {
            if (!Directory.Exists(Application.persistentDataPath))
                Directory.CreateDirectory(Application.persistentDataPath);
            file = File.Create(SavePath);
            var bf = new BinaryFormatter();
            bf.Serialize(file, saveData);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        finally
        {
            if (file != null)
                file.Close();
        }
    }
    //
    //Exit application

    public void OnTutorialButtonClick()
    {
        tutorialCanvas.SetActive(true);
    }

    public void OnTutorialExitClick()
    {
        tutorialCanvas.SetActive(false);
    }

    public void OnTutorialLivesClick()
    {
        LivesCanvas.SetActive(true);
    }

    public void OnTutorialShieldClick()
    {
       ShieldCanvas.SetActive(true);
    }

    public void OnTutorialHealthClick()
    {
        HealthCanvas.SetActive(true);
    }

    public void OnTutorialHeatClick()
    {
        HeatCanvas.SetActive(true);
    }

    public void OnTutorialAbilitiesClick()
    {
        AbilitiesCanvas.SetActive(true);
    }

    public void OnAnyTutorialExitClick()
    {
        LivesCanvas.SetActive(false);
        ShieldCanvas.SetActive(false) ;
        HeatCanvas.SetActive(false);
        HealthCanvas.SetActive(false);
        AbilitiesCanvas.SetActive(false);
    }



    public void OnExitAppButtonClick()
    { ExitCanvas.SetActive(true); }

    public void OnExitAppButtonYes()
    { Application.Quit(); }

    public void OnExitAppButtonNo()
    { ExitCanvas.SetActive(false); }
    //
    //going to level choice
    public void OnStartButtonClick()
    {
        StartCanvas.SetActive(true);
    }
    //
    //exiting level choice
    public void OnExitStartButtonClick()
    { StartCanvas.SetActive(false); }
    //
    //level 1 choice
    public void Level1ButtonClick()
    { SceneManager.LoadScene("Neptune"); }
    //
    //level 2 choice
    public void Level2ButtonClick()
    { if (saveData.lvl2 == true) SceneManager.LoadScene("Sodom"); }
    //
    //level 3 choice
    public void Level3ButtonClick()
    { if (saveData.lvl3 == true) SceneManager.LoadScene("GreenPasture"); }
    //
    //level 4 choice
    public void Level4ButtonClick()
    { if (saveData.lvl4 == true) SceneManager.LoadScene("Treason"); }
    //
    //level 5 choice
    public void Level5ButtonClick()
    { if (saveData.lvl5 == true) SceneManager.LoadScene("Persona"); }
    //
    //going to setting
    public void OnSettingButtonClick()
    { SettingCanvas.SetActive(true); }
    //
    //exiting setting
    public void ExitSettingButtonClick()
    { SettingCanvas.SetActive(false); }
    //
    //

    private void Update()
    {
       

    }
}
