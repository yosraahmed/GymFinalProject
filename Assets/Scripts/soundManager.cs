using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{

    public AudioSource effect;
    public AudioSource gameMusic;
    public AudioSource startMusic;
    public AudioSource cubeSound;
    public AudioSource ballSound;

    // Start is called before the first frame update

    private void Awake()
    {
        
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
        gameMusic.Play();
    }

    public void startSound()
    {
        startMusic.Play();
    }
}
