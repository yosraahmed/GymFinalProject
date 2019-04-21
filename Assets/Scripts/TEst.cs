using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEst : MonoBehaviour
{
    public AudioSource effect;
    // Start is called before the first frame update
    void Start()
    {
        effect.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void REloadScene()
    {
        SceneManager.LoadScene(2);
    }
}
