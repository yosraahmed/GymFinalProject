using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMulitplayer : MonoBehaviour
{
    //public GameObject joinRoom;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("JoinRoom", 0);
        NetworkManager.Instance.Disconnect();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("JoinRoom", 0)==1)
        {
           // joinRoom.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("JoinRoom", 0) == 0)
        {
           // joinRoom.SetActive(false);
        }

    }
    public void Connect()
    {
        NetworkManager.Instance.Connect();
    }
    public void JoinRoom()
    {
        PlayerPrefs.SetInt("JoinRoom", 0);
        NetworkManager.Instance.JoinRoom();
    }
    public void Disconnect()
    {
        NetworkManager.Instance.Disconnect();
    }
    
}
