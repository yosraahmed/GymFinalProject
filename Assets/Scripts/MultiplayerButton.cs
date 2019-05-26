using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitButtonMultiplayerFinishGame()
    {
        PlayerPrefs.SetInt("Timer", 0);
        PlayerPrefs.SetInt("PointerP1", 0);
        PlayerPrefs.SetInt("PointerP2", 0);
        NetworkManager.Instance.Disconnect();
        NetworkManager.Instance.DelayCancelExit();
        SceneManager.LoadScene("MainMenuTestWithOculus");
    }
}
