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

        if (sceneName == "MainMenuTestWithOculus")
        {
            print("play");
            gamePlayMusic.Stop();
            startSound();

        }
       
        else if (sceneName == "gameScene2")
        {
            startManuMusic.Stop();
            gameSound();
        }
    }
}
