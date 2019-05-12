using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    #region Vars
    string gameVersion = "1";
    const int MAXPLAYERCOUNT = 1;
    #endregion

    #region Properties
    public static NetworkManager Instance { get; set; }
    #endregion

    #region Methods
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = gameVersion;
    }

    public override void OnConnectedToMaster()
    {
        print("Connected");
        JoinRoom();
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
    }

    public void JoinRoom()
    {   
        if (PhotonNetwork.IsConnectedAndReady)
            PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = MAXPLAYERCOUNT }, null);

        base.OnJoinRandomFailed(returnCode, message);
    }

    public override void OnJoinedRoom()
    {
        print("JoinedRoom");
        if (PhotonNetwork.CurrentRoom.PlayerCount >= MAXPLAYERCOUNT)
            Invoke("StartGame", 3);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount >= MAXPLAYERCOUNT)
            Invoke("StartGame", 3);

        base.OnPlayerEnteredRoom(newPlayer);
    }

    void StartGame()
    {
        PhotonNetwork.LoadLevel("Multiplayer2");
    }
    #endregion
}
