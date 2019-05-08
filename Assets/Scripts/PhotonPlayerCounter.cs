using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhotonPlayerCounter : MonoBehaviourPunCallbacks
{
    private PhotonView myPhotonView;
    private int playerCount;
    private int roomSize;
    public Text playerCountDisplay;
    public GameObject GameStartText;
    public GameObject waitForPlayer;

    private void Start()
    {
        if (!PhotonNetwork.IsMasterClient)
        {

        }
        //initialize variables
        myPhotonView = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {

        }
    }

    private void Update()
    {
        playerCount = PhotonNetwork.PlayerList.Length;
        roomSize = 2;
        playerCountDisplay.text = "Players Joind: " +playerCount + "/" + roomSize;
        if (playerCount >= 2)
        {

            GameStartText.SetActive(true);
            waitForPlayer.SetActive(false);
        }
        else if (playerCount <= 1)
        {
            waitForPlayer.SetActive(true);
            GameStartText.SetActive(false);
        }
    }
}


