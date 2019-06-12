using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class photonMyLocationObject : MonoBehaviourPun
{
    public GameObject stage1, stage2;
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine )
        {
            stage1.SetActive(false);

        }
        if (photonView.IsMine )
        {
            stage2.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
