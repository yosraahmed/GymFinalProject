using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Pause : MonoBehaviour
{
    public SteamVR_Input_Sources m_TargetSouce;
    public SteamVR_Action_Boolean m_ClickAction;
    [SerializeField] private GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) || m_ClickAction.GetStateDown(m_TargetSouce) || OVRInput.GetDown(OVRInput.Button.Two))
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
        PlayerPrefs.SetInt("Timer", 0);
        SceneManager.LoadScene("MainMenuTestWithOculus");
    }
    public void ResumeButton()
    {
        ContinueGame();
    }
}
