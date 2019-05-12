using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonOtherPlayerObject : MonoBehaviourPun, IPunObservable
{
   
    Vector3 latestPosR;
    Quaternion latestRotR;
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
        transform.Rotate(0, 0, 4);
        transform.position -= transform.forward * gameManager.instance.BulletSpeed * Time.deltaTime;
        if (!photonView.IsMine)
        {
            //Update remote player (smooth this, this looks good, at the cost of some accuracy)
            transform.position = Vector3.Lerp(transform.position, latestPosR, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, latestRotR, Time.deltaTime * 5);
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
            latestPosR = (Vector3)stream.ReceiveNext();
            latestRotR = (Quaternion)stream.ReceiveNext();
        }
    }
}
