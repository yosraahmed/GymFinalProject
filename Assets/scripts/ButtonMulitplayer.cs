using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMulitplayer : MonoBehaviour
{
    public GameObject joinRoom;
    public GameObject disconnect;
    public GameObject ConnectingText;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("JoinRoom", 0);
        NetworkManager.Instance.Disconnect();
        PlayerPrefs.SetInt("ConnectingText", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("JoinRoom", 0)==1)
        {
            PlayerPrefs.SetInt("ConnectingText", 0);
            joinRoom.SetActive(true);
            disconnect.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("JoinRoom", 0) == 0)
        {
            joinRoom.SetActive(false);
            disconnect.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ConnectingText", 0) == 1)
        {
            ConnectingText.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("ConnectingText", 0) == 0)
        {
            ConnectingText.SetActive(false);
        }

    }
    public void Connect()
    {
        PlayerPrefs.SetInt("ConnectingText", 1);
        NetworkManager.Instance.Connect();

    }
    public void JoinRoom()
    {
        PlayerPrefs.SetInt("JoinRoom", 0);
        NetworkManager.Instance.JoinRoom();
    }
    public void Disconnect()
    {
        PlayerPrefs.SetInt("JoinRoom", 0);
        NetworkManager.Instance.Disconnect();
    }
    
}
