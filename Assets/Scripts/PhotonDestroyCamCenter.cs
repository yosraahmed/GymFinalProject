using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonDestroyCamCenter : MonoBehaviourPun
{
    private Camera cam;
    private AudioListener audio1;

    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine )
        {
            Destroy(GetComponent<Camera>());
            Destroy(GetComponent<AudioListener>());
        }
        if (photonView.IsMine)
        {
            cam = GetComponent<Camera>();
            audio1 = GetComponent<AudioListener>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
