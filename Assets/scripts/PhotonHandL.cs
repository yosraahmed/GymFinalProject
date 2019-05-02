using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonHandL : MonoBehaviourPun, IPunObservable
{
   
    Vector3 latestPosL;
    Quaternion latestRotL;
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
        if (!photonView.IsMine)
        {
            //Update remote player (smooth this, this looks good, at the cost of some accuracy)
            transform.position = Vector3.Lerp(transform.position, latestPosL, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, latestRotL, Time.deltaTime * 5);
        }

        //if (PV.IsMine)
        //{
            
        //}
        //if (photonView.IsMine)
        //    return;
    }
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //We own this player: send the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            //Network player, receive data
            latestPosL = (Vector3)stream.ReceiveNext();
            latestRotL = (Quaternion)stream.ReceiveNext();
        }
    }
}
