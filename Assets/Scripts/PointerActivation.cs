using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Valve.VR;

public class PointerActivation : MonoBehaviour
{
    public GameObject pointerOnOff;
    public GameObject inputOnOff;
    //public SteamVR_Input_Sources m_TargetSouce;
    //public SteamVR_Action_Boolean m_ClickAction;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Timer", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Timer", 0)==1 /*||OVRInput.Get(OVRInput.Button.Start)*/ )
        {
                pointerOnOff.SetActive(true);
                inputOnOff.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Timer", 0) == 0 /*||OVRInput.Get(OVRInput.Button.Start)*/ )
        {
            pointerOnOff.SetActive(false);
            inputOnOff.SetActive(false);
        }
    }
}
