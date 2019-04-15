using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameScript : MonoBehaviour
{
    public int hr = 1;
    public int minutes;
    public int second = 0;
    public float timeRemain;
    public Text gameTimerText;
    // Start is called before the first frame update
    void Start()
    {
        hr = 0;
        minutes = 59;
        second = 59;
    }

    // Update is called once per frame
    void Update()
    {
       
        
            if (minutes == 0 && hr >= 1)
            {
                hr--;
                minutes = 59;
            }

            if (second == 0 && minutes >= 1)
            {
                second = 59;
                minutes--;
            }
           else if( second >= 1)
                second--;

            gameTimerText.text = hr + ":" + minutes + ":" + second;
        
        if(hr == 0 && minutes == 0 && second == 0)
        {
            SceneManager.LoadScene("MainMenuTestWithOculus");
        }

        //if (hr <= 0)
        //{
        //    gameTimerText.text = "STOP!";
        //}

    }
}
