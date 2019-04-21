using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject levelMenu;
    public GameObject startMenu;
    public GameObject setting;
    public GameObject musicOn;
    public GameObject musicOff;
    public int counter = 4;
    public float timeCounter = 1;
    public Text counterText;

    public bool isBoxing;
    public bool isSquats; 

    //public soundManager sounds;

    //public soundManager sounds;
 
    //public soundManager sounds;

    void Start()
    {
        mainmenu.SetActive(true);
        levelMenu.SetActive(false);
        startMenu.SetActive(false);
        setting.SetActive(false);
        counter = 4;
        timeCounter = 1;
        //sounds = GetComponent<soundManager>();
    }

    public void Update()
    { 
        counterText.text = counter.ToString();

        if(counter == 3)
        {
           // sounds.startSound();
            timeCounter -= Time.deltaTime;
            if(timeCounter <= 0)
            {
                counter = 2;
                timeCounter = 1;
            }
        }
        if(counter == 2)
        {
           // sounds.startSound();
            timeCounter -= Time.deltaTime;
            if (timeCounter <= 0)
            {
                counter = 1;
                timeCounter = 1;
            }
        }
        if (counter == 1)
        {
          //  sounds.startSound();
            timeCounter -= Time.deltaTime;
            if (timeCounter <= 0 && PlayerPrefs.GetInt("isSquats", 0) == 1)
            {
                print("SQUAT");
                SceneManager.LoadScene("gameScene2");
                timeCounter = 1;
                //soundManager.instance.gameSound();
            }
            else if (timeCounter <= 0 && PlayerPrefs.GetInt("isBoxing", 0) == 3)
            {
                print("BOXING");
                SceneManager.LoadScene("boxingScene");
                timeCounter = 1;
            }
        }
    }
    public void MusicOnOff()
    {
        if (PlayerPrefs.GetInt("SoundMusic", 0) == 0)
        {
            PlayerPrefs.SetInt("SoundMusic", 1);
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("SoundMusic", 0) == 1)
        {
            PlayerPrefs.SetInt("SoundMusic", 0);
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }
    }
 
    public void Settings()
    {
        mainmenu.SetActive(false);
        setting.SetActive(true);
    }
    public void SettingsExit()
    {
        mainmenu.SetActive(true);
        setting.SetActive(false);
    }

    public void exericeseTypeSquats()
    {
        mainmenu.SetActive(false);
        levelMenu.SetActive(true);
        PlayerPrefs.SetInt("isSquats", 1);
        PlayerPrefs.SetInt("isBoxing", 0);

    }

    public void exericeseTypeBoxing()
    {
        // sounds.startSound();
        //soundManager.instance.effectSound();
        mainmenu.SetActive(false);
        levelMenu.SetActive(true);
        PlayerPrefs.SetInt("isBoxing", 3);
        PlayerPrefs.SetInt("isSquats", 0);
    }

    public void levelButtons()
    {
        // sounds.startSound();
        //soundManager.instance.effectSound();
        mainmenu.SetActive(false);
        levelMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void startGame() 
    {
        //soundManager.instance.effectSound();
        counter = 3;
    }

    public void backToMain()
    {
        soundManager.instance.effectSound();
        mainmenu.SetActive(true);
        levelMenu.SetActive(false);
    }

    public void backToLevel()
    {
        soundManager.instance.effectSound();
        startMenu.SetActive(false);
        mainmenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
 
}
