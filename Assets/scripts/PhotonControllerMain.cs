using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonControllerMain : MonoBehaviourPun, IPunObservable
{
    
    private CharacterController myCC;
    public Camera camFalse;
    public OVRCameraRig rig;
    public OVRManager covrManager;
    public OVRHeadsetEmulator OVRHE;
    public BoxCollider RightHand;
    public BoxCollider LefttHand;
    public SphereCollider Head;
    public playerController RightHandScript;
    public playerController LeftHandScript;
    public playerController HeadScript;
    public float speeds;
    Vector3 latestPos;
    Quaternion latestRot;
    // Start is called before the first frame update

    void Start()
    {
        if (!photonView.IsMine /*&& GetComponent<OVRCameraRig>() != null*/)
        {

            OVRHE.enabled = (false);
            //covrManager.enabled = (false);
            rig.enabled = (false);
            camFalse.enabled = (false);
            RightHand.enabled = (false);
            LefttHand.enabled = (false);
            Head.enabled = (false);
            RightHandScript.enabled = (false);
            LeftHandScript.enabled = (false);
            HeadScript.enabled = (false);

            Destroy(GetComponent<OVRPlayerController>());
            Destroy(GetComponent<OVRDebugInfo>());
            Destroy(GetComponent<OVRSceneSampleController>());
            Destroy(GetComponent<CharacterController>());



        }
        if (photonView.IsMine)
        {
            myCC = GetComponent<CharacterController>();
        }

    }
   
    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            //Update remote player (smooth this, this looks good, at the cost of some accuracy)
            transform.position = Vector3.Lerp(transform.position, latestPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, latestRot, Time.deltaTime * 5);
        }

        if (photonView.IsMine)
        {
            movment();
        }
        //if (photonView.IsMine)
        //    return;
    }
    public void movment()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myCC.Move(transform.forward * Time.deltaTime * speeds);
        }
        if (Input.GetKey(KeyCode.S))
        {
            myCC.Move(-transform.forward * Time.deltaTime * speeds);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myCC.Move(-transform.right * Time.deltaTime * speeds);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myCC.Move(transform.right * Time.deltaTime * speeds);
        }
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
            latestPos = (Vector3)stream.ReceiveNext();
            latestRot = (Quaternion)stream.ReceiveNext();
        }
    }
}
