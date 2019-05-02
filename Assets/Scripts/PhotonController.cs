using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonController : MonoBehaviourPun
{
    


 
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine /*&& GetComponent<OVRCameraRig>() != null*/)
        {

            //Destroy(GetComponent<OVRCameraRig>());
            //Destroy(GetComponent<OVRManager>());
            //Destroy(GetComponent<OVRHeadsetEmulator>());


        }

        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

 

}
