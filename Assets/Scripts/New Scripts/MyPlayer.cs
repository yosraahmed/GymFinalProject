using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MyPlayer : MonoBehaviourPun, IPunObservable
{

    public CharacterController MyCharacterController { get; set; }
    public GameObject camra;
    public float speeds;
    Vector3 latestPos;
    Quaternion latestRot;
    // Start is called before the first frame update

    void Start()
    {
        if (photonView.IsMine )
        {
            PlayerContoller.Instance.LocalVivePlayerInstance = this;
            MyCharacterController = GetComponent<CharacterController>();
        }
        else
        {
            camra.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (!photonView.IsMine)
        //{
        //    //Update remote player (smooth this, this looks good, at the cost of some accuracy)
        //    transform.position = Vector3.Lerp(transform.position, latestPos, Time.deltaTime * 5);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, latestRot, Time.deltaTime * 5);
        //}

        //if (photonView.IsMine)
        //{
        //    movment();
        //}
        //if (photonView.IsMine)
        //    return;
    }
    public void movment()
    {
        
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //if (stream.IsWriting)
        //{
        //    //We own this player: send the others our data
        //    stream.SendNext(transform.position);
        //    stream.SendNext(transform.rotation);
        //}
        //else
        //{
        //    //Network player, receive data
        //    latestPos = (Vector3)stream.ReceiveNext();
        //    latestRot = (Quaternion)stream.ReceiveNext();
        //}
    }
}
