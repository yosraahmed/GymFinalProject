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
    public int counter = 4;
    public float timeCounter = 1;
    public Text counterText;
    public soundManager sounds;
  


    void Start()
    {
        mainmenu.SetActive(true);
        levelMenu.SetActive(false);
        startMenu.SetActive(false);
        counter = 4;
        timeCounter = 1;
        sounds = GetComponent<soundManager>();

        
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
            if (timeCounter <= 0)
            {
                SceneManager.LoadScene("gameScene");
                timeCounter = 1;
                sounds.gameSound();

            }

        }
       
    }


    public void exericeseType()
    {
        // sounds.startSound();
        sounds.effectSound();
        mainmenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void levelButtons()
    {
        // sounds.startSound();
        sounds.effectSound();
        mainmenu.SetActive(false);
        levelMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void startGame() 
    {
        sounds.effectSound();
        counter = 3;
    }

    public void backToMain()
    {
        sounds.effectSound();
        mainmenu.SetActive(true);
        levelMenu.SetActive(false);
    }

    public void backToLevel()
    {
        sounds.effectSound();
        startMenu.SetActive(false);
        mainmenu.SetActive(false);
        levelMenu.SetActive(true);
    }

}
