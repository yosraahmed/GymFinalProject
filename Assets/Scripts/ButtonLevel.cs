using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("EasySquat", 0);
        PlayerPrefs.SetInt("NormalSquat", 0);
        PlayerPrefs.SetInt("HardSquat", 0);

        PlayerPrefs.SetInt("EasyBoxing", 0);
        PlayerPrefs.SetInt("NormalBoxing", 0);
        PlayerPrefs.SetInt("HardBoxing", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void levelButtonsSquatEasy()
    {
         uiManager.instance.levelButtons();
        PlayerPrefs.SetInt("EasySquat", 1);
        PlayerPrefs.SetInt("NormalSquat", 0);
        PlayerPrefs.SetInt("HardSquat", 0);
    }
    public void levelButtonsSquatNormal()
    {
        uiManager.instance.levelButtons();
        PlayerPrefs.SetInt("EasySquat", 0);
        PlayerPrefs.SetInt("NormalSquat", 1);
        PlayerPrefs.SetInt("HardSquat", 0);
    }
    public void levelButtonsSquatHard()
    {
        uiManager.instance.levelButtons();
        PlayerPrefs.SetInt("EasySquat", 0);
        PlayerPrefs.SetInt("NormalSquat", 0);
        PlayerPrefs.SetInt("HardSquat", 1);
    }
    public void levelButtonsBoxingEasy()
    {
        uiManager.instance.levelButtons();
        PlayerPrefs.SetInt("EasyBoxing", 1);
        PlayerPrefs.SetInt("NormalBoxing", 0);
        PlayerPrefs.SetInt("HardBoxing", 0);
    }
    public void levelButtonsBoxingNormal()
    {
        uiManager.instance.levelButtons();
        PlayerPrefs.SetInt("EasyBoxing", 0);
        PlayerPrefs.SetInt("NormalBoxing", 1);
        PlayerPrefs.SetInt("HardBoxing", 0);
    }
    public void levelButtonsBoxingHard()
    {
        uiManager.instance.levelButtons();
        PlayerPrefs.SetInt("EasyBoxing", 0);
        PlayerPrefs.SetInt("NormalBoxing", 0);
        PlayerPrefs.SetInt("HardBoxing", 1);
    }
}
