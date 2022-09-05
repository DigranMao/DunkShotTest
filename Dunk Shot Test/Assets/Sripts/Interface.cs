using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    public GameObject Ingame;
    public GameObject MainMenu;
    public GameObject Resume;
    public GameObject Paused;
    public GameObject Settings;
    public GameObject[] backgroundAllGray;
    public GameObject[] backgroundAllBlack;
    public GameObject Off;
    public GameObject On;
    public Camera backgroundCamera;

    public bool ingame = false;
    public bool mainMenu = true;
    public bool resume = false;
    bool paused = false;
    bool settings = false;
    bool background = true;

    void Start()
    {
        mainMenu = true;
        background = true;
    }
    
    void Update()
    {
        if(ingame)
        {   Ingame.SetActive(true);
            mainMenu = false;   
        }
        else Ingame.SetActive(false);

        if(mainMenu) MainMenu.SetActive(true);
        else MainMenu.SetActive(false);

        if(resume)  Resume.SetActive(true);
        else Resume.SetActive(false);

        if(paused) Paused.SetActive(true);
        else Paused.SetActive(false);

        if(settings) Settings.SetActive(true);
        else    Settings.SetActive(false);

        if(background)
        {
            Off.SetActive(true);
            On.SetActive(false);
            backgroundCamera.backgroundColor = new Color(0.9f, 0.9f, 0.9f, 1);
            
            foreach(GameObject BackGray in backgroundAllGray)
                BackGray.SetActive(true);

            foreach(GameObject BackBlack in backgroundAllBlack)
                BackBlack.SetActive(false);
        }
        else
        {
            On.SetActive(true);
            Off.SetActive(false);
            backgroundCamera.backgroundColor = new Color(0.2f, 0.2f, 0.2f, 1);

            foreach(GameObject BackGray in backgroundAllGray)
                BackGray.SetActive(false);
                
            foreach(GameObject BackBlack in backgroundAllBlack)
                BackBlack.SetActive(true);
        }
    }

    public void BackgroundOffAndOn()
    {background = !background;}

    public void MainMenuClose()
    {MainMenu.SetActive(false);}
        
    public void MainMenuOpen()
    {   SceneManager.LoadScene(0);
        Time.timeScale = 1f;}
   
    public void PausedOpen()
    {   paused = true;
        Time.timeScale = 0f;}
  
        
    public void PausedClose()
    {   Time.timeScale = 1f;
        paused = false;}
        
    public void SettingsClose()
    {   settings = false;}
        
    public void SettingsOpen()
    {   settings = true;}
        
  


}
