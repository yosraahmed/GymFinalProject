using System;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Photon.Pun.UtilityScripts;

public class CountdownTimer1 : MonoBehaviourPunCallbacks
{
    public Text countext;
    bool startTimer = false;
    double timerIncrementValue;
    double startTime;
    [SerializeField] double timer = 20;
    ExitGames.Client.Photon.Hashtable CustomeValue;

    void Start()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            CustomeValue = new ExitGames.Client.Photon.Hashtable();
            startTime = PhotonNetwork.Time;
            startTimer = true;
            CustomeValue.Add("StartTime", startTime);

            PhotonNetwork.CurrentRoom.SetCustomProperties(CustomeValue);
        }
        else
        {
            startTime = double.Parse(PhotonNetwork.CurrentRoom.CustomProperties["StartTime"].ToString());
            startTimer = true;
        }
    }

    void Update()
    {
        string tempTimer = string.Format("{0:00}", timerIncrementValue);
        countext.text = tempTimer;
        if (!startTimer) return;
        timerIncrementValue = PhotonNetwork.Time - startTime;
        if (timerIncrementValue >= timer)
        {
            //Timer Completed
            //Do What Ever You What to Do Here
        }
    }
}