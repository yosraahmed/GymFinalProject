using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhotonTimer : MonoBehaviourPunCallbacks
{
    //bool startTimer = false;
    //double timerIncrementValue;
    //double startTime;
    //[SerializeField] double timer = 20;
    //ExitGames.Client.Photon.Hashtable CustomeValue;

    //void Start()
    //{
    //    if (PhotonNetwork.player.IsMasterClient)
    //    {
    //        CustomeValue = new ExitGames.Client.Photon.Hashtable();
    //        startTime = PhotonNetwork.Time;
    //        startTimer = true;
    //        CustomeValue.Add("StartTime", startTime);

    //        PhotonNetwork.room.SetCustomProperties(CustomeValue);
    //    }
    //    else
    //    {
    //        startTime = double.Parse(PhotonNetwork.room.CustomProperties["StartTime"].ToString());
    //        startTimer = true;
    //    }
    //}

    //void Update()
    //{
    //    if (!startTimer) return;
    //    timerIncrementValue = PhotonNetwork.Time - startTime;
    //    if (timerIncrementValue >= timer)
    //    {
    //        //Timer Completed
    //        //Do What Ever You What to Do Here
    //    }
    //}

    /*This object must be attached to an object
     / in the waiting room scene of your project.*/

    // photon view for sending rpc that updates the timer
    private PhotonView myPhotonView;

    // scene navigation indexes
    [SerializeField]
    private int multiplayerSceneIndex;
    [SerializeField]
    private int menuSceneIndex;
    // number of players in the room out of the total room size
    private int playerCount;
    private int roomSize;
    [SerializeField]
    private int minPlayersToStart;

    // text variables for holding the displays for the countdown timer and player count
    [SerializeField]
    private Text playerCountDisplay;
    [SerializeField]
    private Text timerToStartDisplay;

    // bool values for if the timer can count down
    private bool readyToCountDown;
    //private bool readyToStart;
    private bool startingGame;
    //countdown timer variables
    [SerializeField]
    private float timerToStartGame;
    private float notFullRoomTimer;
    [SerializeField]
    private float fullRoomTimer;
    //countdown timer reset variables
    [SerializeField]
    private float maxWaitTime;
    [SerializeField]
    private float maxFullRoomWaitTime;

    private void Start()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            timerToStartGame = 90;
        }
            //initialize variables
            myPhotonView = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {
            fullRoomTimer = maxFullRoomWaitTime;
            notFullRoomTimer = maxWaitTime;
            timerToStartGame = maxWaitTime;
        }
        PlayerCountUpdate();
    }

    void PlayerCountUpdate()
    {
        // updates player count when players join the room
        // displays player count
        // triggers countdown timer
        playerCount = PhotonNetwork.PlayerList.Length;
        roomSize = PhotonNetwork.CurrentRoom.MaxPlayers;
        playerCountDisplay.text = playerCount + ":" + roomSize;

        //if (playerCount == roomSize)
        //{
        //    readyToStart = true;
        //}
        /*else*/ if (playerCount >= minPlayersToStart)
        {
            readyToCountDown = true;
        }
        else
        {
            readyToCountDown = false;
            //readyToStart = false;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //called whenever a new player joins the room
        PlayerCountUpdate();
        //send master clients countdown timer to all other players in order to sync time.
        //if (PhotonNetwork.IsMasterClient)
        //    myPhotonView.RPC("RPC_SyncTimer", RpcTarget.Others, timerToStartGame);
    }

    [PunRPC]
    private void RPC_SyncTimer(float timeIn)
    {
        //RPC for syncing the countdown timer to those that join after it has started the countdown
        timerToStartGame = timeIn;
        notFullRoomTimer = timeIn;
        if (timeIn < fullRoomTimer)
        {
            fullRoomTimer = timeIn;
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //called whenever a player leaves the room
        PlayerCountUpdate();
    }

    private void Update()
    {
        WaitingForMorePlayers();
    }

    void WaitingForMorePlayers()
    {
        if (PhotonNetwork.IsMasterClient)
            myPhotonView.RPC("RPC_SyncTimer", RpcTarget.Others, timerToStartGame);

        //If there is only one player in the room the timer will stop and reset
        //if (playerCount <= 1)
        //{
        //    ResetTimer();
        //}
        // when there is enough players in the room the start timer will begin counting down
        //if (readyToStart)
        //{
        //    fullRoomTimer -= Time.deltaTime;
        //    timerToStartGame = fullRoomTimer;
        //}
        /*else */
        if (PhotonNetwork.IsMasterClient)
        {
            if (readyToCountDown)
            {
                notFullRoomTimer -= Time.deltaTime;
                timerToStartGame = notFullRoomTimer;
            }
        }
        // format and display countdown timer
        string tempTimer = string.Format("{0:00}", timerToStartGame);
        timerToStartDisplay.text = tempTimer;
        // if the countdown timer reaches 0 the game will then start
        if (timerToStartGame <= 0f)
        {

            if (startingGame)
                return;
            StartGame();
        }
    }

    void ResetTimer()
    {
        //resets the count down timer
        timerToStartGame = maxWaitTime;
        notFullRoomTimer = maxWaitTime;
        fullRoomTimer = maxFullRoomWaitTime;
    }

    void StartGame()
    {
        //Multiplayer scene is loaded to start the game
        startingGame = true;
        if (!PhotonNetwork.IsMasterClient)
            return;
        PhotonNetwork.CurrentRoom.IsOpen = false;
        //PhotonNetwork.LeaveRoom();
        //PhotonNetwork.Disconnect();
        //SceneManager.LoadScene(menuSceneIndex);
        PhotonNetwork.LoadLevel(multiplayerSceneIndex);
    }

    public void DelayCancel()
    {
        //public function paired to cancel button in waiting room scene
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(menuSceneIndex);
    }
}


