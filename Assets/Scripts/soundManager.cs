using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class soundManager : MonoBehaviour
{
    public static soundManager instance;
    public AudioSource effect;
    public AudioSource gamePlayMusic;
    public AudioSource startManuMusic;
    public AudioSource cubeSound;
    public AudioSource ballSound;

    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

        PlayerPrefs.SetInt("SoundMusic", 1);

    }

    public void effectSound()
    {

        effect.Play();
    }
  
    public void gameSound()
    {
        gamePlayMusic.Play();
    }

    public void startSound()
    {
        startManuMusic.Play();
    }
    public void CubeCrashSound()
    {
        cubeSound.Play();
    }
    public void BallCrashSound()
    {
        ballSound.Play();
    }
     void Update()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "MainMenuTestWithOculus" && PlayerPrefs.GetInt("SoundMusic", 0) == 1)
        {
            if (!startManuMusic.isPlaying)
            {
                gamePlayMusic.Stop();
                startManuMusic.Play();
            }
           
        }
        else if (sceneName == "gameScene2" && PlayerPrefs.GetInt("SoundMusic", 0) == 1)
        {
            if (!gamePlayMusic.isPlaying )
            {
                startManuMusic.Stop();
                gamePlayMusic.Play();
            }
           
        }
        else if (PlayerPrefs.GetInt("SoundMusic", 0) == 0)
        {
            startManuMusic.Stop();
            gamePlayMusic.Stop();
        }

    }
    public void soundMute()
    {
        if (PlayerPrefs.GetInt("SoundMusic",0)==1)
        {
            PlayerPrefs.SetInt("SoundMusic", 0);
        }
        else
        {
            PlayerPrefs.SetInt("SoundMusic", 1);
        }
    }
}
