using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public static uiManager instance;
    public GameObject mainmenu;
    public GameObject multiPlayerMenu;
    public GameObject levelMenuSquats;
    public GameObject levelMenuBoxing;
    public GameObject startMenu;
    public GameObject setting;
    public GameObject musicOn;
    public GameObject musicOff;
    public GameObject EasyBoxingInstruction;
    public GameObject MediumBoxingInstruction;
    public GameObject HardBoxingInstruction;
    public GameObject SquatsInstruction;
    public int counter = 4;
    public float timeCounter = 1;
    public Text counterText;
    public bool isBoxing;
    public bool isSquats; 


    void Start()
    {

        
        if (instance == null) instance = this;
        else
        {
            Destroy(this);
        }
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "MainMenuTestWithOculus")
        {
            PlayerPrefs.SetInt("EasySquat", 0);
            PlayerPrefs.SetInt("NormalSquat", 0);
            PlayerPrefs.SetInt("HardSquat", 0);

            PlayerPrefs.SetInt("EasyBoxing", 0);
            PlayerPrefs.SetInt("NormalBoxing", 0);
            PlayerPrefs.SetInt("HardBoxing", 0);


            //instruction = PlayerPrefs.GetInt("Easy Boxing Instructions");
            //EasyBoxingInstruction.text = instruction.ToString();

        }
        mainmenu.SetActive(false);
        levelMenuSquats.SetActive(false);
        levelMenuBoxing.SetActive(false);
        startMenu.SetActive(false);
        setting.SetActive(false);
        multiPlayerMenu.SetActive(true);
        counter = 4;
        timeCounter = 1;
    }

    public void Update()
    {
        counterText.text = counter.ToString();

        if(counter == 3)
        {
            timeCounter -= Time.deltaTime;
            if(timeCounter <= 0)
            {
                counter = 2;
                timeCounter = 1;
            }
        }
        if(counter == 2)
        {
             timeCounter -= Time.deltaTime;
            if (timeCounter <= 0)
            {
                counter = 1;
                timeCounter = 1;
            }
        }
        if (counter == 1)
        {
            timeCounter -= Time.deltaTime;
            if (timeCounter <= 0 && PlayerPrefs.GetInt("isSquats", 0) == 1)
            {
                SceneManager.LoadScene("gameScene2");
                timeCounter = 1;
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
        levelMenuSquats.SetActive(true);
        PlayerPrefs.SetInt("isSquats", 1);
        PlayerPrefs.SetInt("isBoxing", 0);

    }

    public void exericeseTypeBoxing()
    {
        mainmenu.SetActive(false);
        levelMenuBoxing.SetActive(true);
        PlayerPrefs.SetInt("isBoxing", 3);
        PlayerPrefs.SetInt("isSquats", 0);
    }

    public void levelButtons()
    {
        mainmenu.SetActive(false);
        levelMenuBoxing.SetActive(false);
        levelMenuSquats.SetActive(false);
        startMenu.SetActive(true);
    }

    public void startGame() 
    {
        counter = 3;
    }

    public void backToMain()
    {
        soundManager.instance.effectSound();
        mainmenu.SetActive(true);
        levelMenuSquats.SetActive(false);
        levelMenuBoxing.SetActive(false);
    }

    public void backToMainFirst()
    {
        soundManager.instance.effectSound();
        startMenu.SetActive(false);
        mainmenu.SetActive(true);
        levelMenuSquats.SetActive(false);
        levelMenuBoxing.SetActive(false);
        PlayerPrefs.SetInt("EasySquat", 0);
        PlayerPrefs.SetInt("NormalSquat", 0);
        PlayerPrefs.SetInt("HardSquat", 0);

        PlayerPrefs.SetInt("EasyBoxing", 0);
        PlayerPrefs.SetInt("NormalBoxing", 0);
        PlayerPrefs.SetInt("HardBoxing", 0);
    }

    public void backToMultiPlayer()
    {
        mainmenu.SetActive(false);
        levelMenuSquats.SetActive(false);
        levelMenuBoxing.SetActive(false);
        startMenu.SetActive(false);
        multiPlayerMenu.SetActive(true);
    }
    
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void levelButtonsSquatEasy()
    {
        uiManager.instance.levelButtons();
        PlayerPrefs.SetInt("EasySquat", 1);
        PlayerPrefs.SetInt("NormalSquat", 0);
        PlayerPrefs.SetInt("HardSquat", 0);
        SquatsInstruction.SetActive(true);
    }
    public void levelButtonsSquatNormal()
    {
        uiManager.instance.levelButtons();
        PlayerPrefs.SetInt("EasySquat", 0);
        PlayerPrefs.SetInt("NormalSquat", 1);
        PlayerPrefs.SetInt("HardSquat", 0);
        SquatsInstruction.SetActive(true);
    }
    public void levelButtonsSquatHard()
    {
        uiManager.instance.levelButtons();
        PlayerPrefs.SetInt("EasySquat", 0);
        PlayerPrefs.SetInt("NormalSquat", 0);
        PlayerPrefs.SetInt("HardSquat", 1);
        SquatsInstruction.SetActive(true);
    }
    public void levelButtonsBoxingEasy()
    {
        uiManager.instance.levelButtons();
        PlayerPrefs.SetInt("EasyBoxing", 1);
        PlayerPrefs.SetInt("NormalBoxing", 0);
        PlayerPrefs.SetInt("HardBoxing", 0);
        EasyBoxingInstruction.SetActive(true);
        MediumBoxingInstruction.SetActive(false);
        HardBoxingInstruction.SetActive(false);
        // PlayerPrefs.GetString("easyBoxingInstruction", EasyBoxingInstruction);

        // PlayerPrefs.SetInt("Easy Boxing Instructions", instruction);
        //EasyBoxingInstruction.text = instruction.ToString();

    }
    public void levelButtonsBoxingNormal()
    {
        uiManager.instance.levelButtons();
        PlayerPrefs.SetInt("EasyBoxing", 0);
        PlayerPrefs.SetInt("NormalBoxing", 1);
        PlayerPrefs.SetInt("HardBoxing", 0);

        EasyBoxingInstruction.SetActive(false);
        MediumBoxingInstruction.SetActive(true);
        HardBoxingInstruction.SetActive(false);

    }
    public void levelButtonsBoxingHard()
    {
        uiManager.instance.levelButtons();
        PlayerPrefs.SetInt("EasyBoxing", 0);
        PlayerPrefs.SetInt("NormalBoxing", 0);
        PlayerPrefs.SetInt("HardBoxing", 1);

        EasyBoxingInstruction.SetActive(false);
        MediumBoxingInstruction.SetActive(false);
        HardBoxingInstruction.SetActive(true);
    }

    public void multiPlayer()
    {
        mainmenu.SetActive(true);
        levelMenuSquats.SetActive(false);
        levelMenuBoxing.SetActive(false);
        startMenu.SetActive(false);
        multiPlayerMenu.SetActive(false);



    }
}
