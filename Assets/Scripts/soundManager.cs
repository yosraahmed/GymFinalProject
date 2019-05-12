using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class soundManager : MonoBehaviour
{
    public static soundManager instance;

    public AudioSource MusicAudioSource;
    public AudioSource SoundEffectAudioSource;

    public AudioClip SquatsMusic;
    public AudioClip BoxingMusic;
    public AudioClip MenuMusic;
    public AudioClip BoxingEffect;
    public AudioClip WrongBallEffect;
    public AudioClip BallEffect;
    public AudioClip CubeEffect;
    public AudioClip ButtonEffect;

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

    public void PlayMusic(AudioClip clip)
    {
        MusicAudioSource.clip = clip;
        MusicAudioSource.Play();
    }

    public void PlaySoundEffect(string clipName)
    {
        switch (clipName)
        {
            case "BoxingEffect":
                SoundEffectAudioSource.clip = BoxingEffect;
                break;
            case "WrongBallEffect":
                SoundEffectAudioSource.clip = WrongBallEffect;
                break;
            case "BallEffect":
                SoundEffectAudioSource.clip = BallEffect;
                break;
            case "CubeEffect":
                SoundEffectAudioSource.clip = CubeEffect;
                break;
            case "ButtonEffect":
                SoundEffectAudioSource.clip = ButtonEffect;
                break;
            default:
                break;
        }
        
        SoundEffectAudioSource.Play();
    }

    void OnLevelWasLoaded(int level)
    {
        MusicAudioSource.Stop();

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "MainMenuTestWithOculus" && PlayerPrefs.GetInt("SoundMusic", 0) == 1)
        {
            if (!startManuMusic.isPlaying)
            {
                PlayMusic(MenuMusic);
            }
        }
        else if (sceneName == "SinglePlayer" && PlayerPrefs.GetInt("SoundMusic", 0) == 1)
        {
            if (!gamePlayMusicSquat.isPlaying)
            {
                PlayMusic(SquatsMusic);
            }
        }
        else if (sceneName == "Multiplayer" && PlayerPrefs.GetInt("SoundMusic", 0) == 1)
        {
            if (!gamePlayMusicSquat.isPlaying)
            {
                PlayMusic(SquatsMusic);
            }
        }
        else if (sceneName == "boxingScene" && PlayerPrefs.GetInt("SoundMusic", 0) == 1)
        {
            if (!gamePlayMusicBoxing.isPlaying)
            {
                PlayMusic(BoxingMusic);
            }
        }
    }

    public void soundMute()
    {
        if (PlayerPrefs.GetInt("SoundMusic", 0) == 1)
        {
            PlayerPrefs.SetInt("SoundMusic", 0);
        }
        else
        {
            PlayerPrefs.SetInt("SoundMusic", 1);
        }
    }
}
