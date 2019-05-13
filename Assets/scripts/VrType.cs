using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class VrType : MonoBehaviourPun
{
    private PhotonView myPhotonView;
    // Start is called before the first frame update
    void Start()
    {
        myPhotonView = GetComponent<PhotonView>();
        // VrType for Oculus=1 & for Vive=2
        PlayerPrefs.SetInt("VRType", 2);
    }

    // Update is called once per frame
    void Update()
    {

        //if (myPhotonView.IsMine)
        //{
            
        //}
        // VrType for Oculus=1 & for Vive=2
        PlayerPrefs.SetInt("VRType", 2);
    }
}
