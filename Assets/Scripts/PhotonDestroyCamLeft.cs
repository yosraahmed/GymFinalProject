using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonDestroyCamLeft : MonoBehaviourPun
{
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine )
        {
            Destroy(GetComponent<Camera>());
            
        }
        if (photonView.IsMine)
        {
            cam = GetComponent<Camera>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
