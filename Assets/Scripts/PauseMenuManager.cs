using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] GameObject SettingCanvas;
    [SerializeField] GameObject ExitCanvas;
    [SerializeField] GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExitAppButtonClick()
    {
        ExitCanvas.SetActive(true);
         }

    //going to setting
    public void OnSettingButtonClick()
    { SettingCanvas.SetActive(true); }
    //
    //exiting setting
    public void ExitSettingButtonClick()
    { SettingCanvas.SetActive(false); }

    public void OnClickGoToMainMenu()
    {
        SceneManager.LoadScene("MenuStart");
    }

    public void OnYesExitClick()
    {
        Application.Quit();
    }

    public void OnNoExitClick()
    {
        ExitCanvas.SetActive(false);
    }

    public void OnContinueBottonClick()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;  
    }
}
