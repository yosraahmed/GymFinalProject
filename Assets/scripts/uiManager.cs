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
  


    void Start()
    {
        mainmenu.SetActive(true);
        levelMenu.SetActive(false);
        startMenu.SetActive(false);
        counter = 4;
        timeCounter = 1;

        
    }

    public void Update()
    {
       
        counterText.text = counter.ToString();

        if(counter == 3)
        {
            // play audioclip3
            timeCounter -= Time.deltaTime;
            if(timeCounter <= 0)
            {
                counter = 2;
                timeCounter = 1;
            }
           

        }
        if(counter == 2)
        {
            //play aodioclip2
            timeCounter -= Time.deltaTime;
            if (timeCounter <= 0)
            {
                counter = 1;
                timeCounter = 1;
            }

        }
        if (counter == 1)
        {
            // play audioclip1
            timeCounter -= Time.deltaTime;
            if (timeCounter <= 0)
            {
                SceneManager.LoadScene("gameScene");
                timeCounter = 1;
            }

        }
       
    }


    public void exericeseType()
    {
        mainmenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void levelButtons()
    {
        mainmenu.SetActive(false);
        levelMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void startGame() 
    {
       
        counter = 3;
    }

    public void backToMain()
    {
        mainmenu.SetActive(true);
        levelMenu.SetActive(false);
    }

    public void backToLevel()
    {
        startMenu.SetActive(false);
        mainmenu.SetActive(false);
        levelMenu.SetActive(true);
    }

}
