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
    public int hr = 0;
    public int minutes=59;
    public float second = 0;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text calP1;
    public Text calP2;
    Text gameTimerText;
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
    [SerializeField]
    private Text timerToStartDisplay2;
    // bool values for if the timer can count down
    private bool readyToCountDown;
    //private bool readyToStart;
    private bool startingGame;
    //countdown timer variables
    [SerializeField]
    private float timerToStartGame;
    //private float notFullRoomTimer;
    //[SerializeField]
    //private float fullRoomTimer;
    //countdown timer reset variables
    //[SerializeField]
    //private float maxWaitTime;
    //[SerializeField]
    //private float maxFullRoomWaitTime;

    private void Start()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            hr = 0;
            minutes = 59;
            second = 0;
            //timerToStartGame = 90;
        }
            //initialize variables
            myPhotonView = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {
            hr = 0;
            minutes = 59;
            second = 0;
            //fullRoomTimer = maxFullRoomWaitTime;
            //notFullRoomTimer = maxWaitTime;
            //timerToStartGame = maxWaitTime;
        }
        PlayerCountUpdate();
    }

    void PlayerCountUpdate()
    {
        // updates player count when players join the room
        // displays player count
        // triggers countdown timer
        playerCount = PhotonNetwork.PlayerList.Length;
        roomSize =2 /*PhotonNetwork.CurrentRoom.MaxPlayers*/;
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
    private void RPC_SyncTimer(int timeIn)
    {
         hr = timeIn;
 
    }
    [PunRPC]
    private void RPC_SyncTimer1(int timeIn1)
    {
       
        minutes = timeIn1;

    }
    [PunRPC]
    private void RPC_SyncTimer2(float timeIn2)
    {
         second = timeIn2;
    }
    [PunRPC]
    private void RPC_player1Score(int Score1)
    {
        PlayerPrefs.SetInt("player1Score", Score1);
        
    }
    [PunRPC]
    private void RPC_player2Score(int Score2)
    {
        PlayerPrefs.SetInt("player2Score", Score2);

    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //called whenever a player leaves the room
        PlayerCountUpdate();
    }

    private void Update()
    {
        WaitingForMorePlayers();
        string tempTimerSecond = string.Format("{0:00}", second);
        string tempTimerMinutes = string.Format("{0:00}", minutes);
        timerToStartDisplay.text = tempTimerMinutes + ":" + tempTimerSecond;
        timerToStartDisplay2.text = tempTimerMinutes + ":" + tempTimerSecond;

        player1ScoreText.text = PlayerPrefs.GetInt("player1Score", 0).ToString();
        player2ScoreText.text = PlayerPrefs.GetInt("player2Score", 0).ToString();
        string tempTimerClr = string.Format("{0:D3}", PlayerPrefs.GetInt("clr", 0));
        calP1.text = tempTimerClr;
        calP2.text = tempTimerClr;
    }

    void WaitingForMorePlayers()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            myPhotonView.RPC("RPC_SyncTimer", RpcTarget.Others, hr);
            myPhotonView.RPC("RPC_SyncTimer1", RpcTarget.Others, minutes);
            myPhotonView.RPC("RPC_SyncTimer2", RpcTarget.Others, second);
            myPhotonView.RPC("RPC_player1Score", RpcTarget.Others, PlayerPrefs.GetInt("scorText", 0));
            PlayerPrefs.SetInt("player1Score", PlayerPrefs.GetInt("scorText", 0));
        }
        if (!PhotonNetwork.IsMasterClient)
        {
              myPhotonView.RPC("RPC_player2Score", RpcTarget.Others, PlayerPrefs.GetInt("scorText", 0));
            PlayerPrefs.SetInt("player2Score", PlayerPrefs.GetInt("scorText", 0));
        }

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

                if (minutes == 0 && hr >= 1)
                {
                    hr-=1;
                    minutes = 59;
                }

                if (second <= 0 && minutes >= 1)
                {
                    second = 59;
                    minutes-=1;
                }
                else if (second >= 0)
                    //if (PlayerPrefs.GetInt("Timer", 0)==0)
                    //{
                    second-=Time.deltaTime;
                //}
                


                //notFullRoomTimer -= Time.deltaTime;
                //timerToStartGame = notFullRoomTimer;
            }
        }
        
       
        // format and display countdown timer
        //string tempTimer = string.Format("{0:00}", timerToStartGame);
        //timerToStartDisplay.text = gameTimerText.text;
        // if the countdown timer reaches 0 the game will then start
        if (/*timerToStartGame <= 0f*/hr == 0 && minutes == 0 && second <= 0)
        {

            if (startingGame)
                return;
            StartGame();
        }
    }

    void ResetTimer()
    {
        //resets the count down timer
        //timerToStartGame = maxWaitTime;
        //notFullRoomTimer = maxWaitTime;
        //fullRoomTimer = maxFullRoomWaitTime;
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


