using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (!pausePanel.activeInHierarchy)
            {
                PauseGame();
            }
            else if (pausePanel.activeInHierarchy)
            {
                ContinueGame();
            }
        }
    }
    private void PauseGame()
    {
        PlayerPrefs.SetInt("Timer", 1);
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0

    }
    private void ContinueGame()
    {
        PlayerPrefs.SetInt("Timer", 0);
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
    }
    public void ExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuTestWithOculus");
    }
    public void ResumeButton()
    {
        ContinueGame();
    }
}
