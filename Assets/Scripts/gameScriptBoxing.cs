using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameScriptBoxing : MonoBehaviour
{
   
    public int hr = 0;
    public int minutes=2;
    public float second = 0;
    public Text gameTimerText;
    public GameObject exitScreen;
    public Text yourScoreText;
    public Text bestScoreText;
    public GameObject pointer;
    public GameObject inputVr;

    public static gameScriptBoxing instance;
  

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        minutes = 2;
        second = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //yourScoreText.text = PlayerPrefs.GetInt("boxingscorText", 0).ToString();
        //bestScoreText.text = PlayerPrefs.GetInt("BestboxingscorText", 0).ToString();


        //if (PlayerPrefs.GetInt("BestboxingscorText", 0)< PlayerPrefs.GetInt("boxingscorText", 0))
        //{
        //    PlayerPrefs.SetInt("BestboxingscorText", PlayerPrefs.GetInt("boxingscorText", 0));
        //}
        yourScoreText.text = PlayerPrefs.GetInt("boxingscorText", 0).ToString();
        bestScoreText.text = PlayerPrefs.GetInt("BestboxingscorText", 0).ToString();


        if (PlayerPrefs.GetInt("BestboxingscorText", 0) < PlayerPrefs.GetInt("boxingscorText", 0))
        {
            PlayerPrefs.SetInt("BestboxingscorText", PlayerPrefs.GetInt("boxingscorText", 0));
        }

        if (second <= 0 && minutes >= 1)
        {
            second = 60;
            minutes-=1;
        }
        else if (second > 0)
        {
            second-=Time.deltaTime;
        }

        
        string tempTimerSecond = string.Format("{0:00}", second);
        string tempTimerMinutes = string.Format("{0:00}", minutes);
        gameTimerText.text = tempTimerMinutes + ":" + tempTimerSecond;
        
        if(hr == 0 && minutes == 0 && second <= 0)
        {
           // SceneManager.LoadScene("MainMenuTestWithOculus");
            exitScreen.SetActive(true);
            pointer.SetActive(true);
            inputVr.SetActive(true);
        }
        else
        {
            exitScreen.SetActive(false);
            pointer.SetActive(false);
            inputVr.SetActive(false);
        }

    }
    public void ExitGameScene()
    {
        SceneManager.LoadScene("MainMenuTestWithOculus");
    }
    
}


