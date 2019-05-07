﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviourPunCallbacks
{
    public Text ScourText;
    public Text clr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string tempTimer = string.Format("{0:D3}", PlayerPrefs.GetInt("scorText", 0));
        ScourText.text = tempTimer;
        string tempTimer2 = string.Format("{0:D3}", PlayerPrefs.GetInt("clr", 0));
        clr.text = tempTimer2;
    }
}
