using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMulitplayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Instance.Disconnect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Connect()
    {
        NetworkManager.Instance.Connect();
    }
    public void JoinRoom()
    {
        NetworkManager.Instance.JoinRoom();
    }
    public void Disconnect()
    {
        NetworkManager.Instance.Disconnect();
    }
    
}
