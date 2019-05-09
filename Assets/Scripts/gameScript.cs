using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameScript : MonoBehaviour
{
   
    public int hr = 1;
    public int minutes;
    public float second = 0;
    public Text gameTimerText;

    // Start is called before the first frame update
    void Start()
    {
        
        minutes = 5;
        second = 59;
    }

    // Update is called once per frame
    void Update()
    {

     

       

        if (second <= 0 && minutes >= 1)
        {
            second = 60;
            minutes-=1;
        }
        else if (second >= 0)
        {
            second-=Time.deltaTime;
        }


        string tempTimerSecond = string.Format("{0:00}", second);
        string tempTimerMinutes = string.Format("{0:00}", minutes);
        gameTimerText.text = tempTimerMinutes + ":" + tempTimerSecond;
        
        if(hr == 0 && minutes == 0 && second == 0)
        {
            SceneManager.LoadScene("MainMenuTestWithOculus");
        }

      

    }
    
}


