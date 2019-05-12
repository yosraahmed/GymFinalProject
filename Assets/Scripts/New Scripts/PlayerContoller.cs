using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviourPun
{
    public static PlayerContoller Instance;

    public MyPlayer LocalVivePlayerInstance { get; set; }
    public MyPlayerOculus LocalOculusPLayerInstance { get; set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PlayerPrefs.GetInt("VRType", 0) == 1)
            {
                PhotonNetwork.Instantiate("OculusMultiplayer2", GameObject.Find("PlayerOneLocation").transform.position, Quaternion.identity, 0);
               
            }
            else if (PlayerPrefs.GetInt("VRType", 0) == 2)
            {
                PhotonNetwork.Instantiate("VivePlayer2", GameObject.Find("PlayerOneLocation").transform.position, Quaternion.identity, 0);
               
            }
        }
        if (!PhotonNetwork.IsMasterClient)
        {
            if (PlayerPrefs.GetInt("VRType", 0) == 1)
            {
                PhotonNetwork.Instantiate("OculusMultiplayer2", GameObject.Find("PlayerTwoLocation").transform.position, Quaternion.identity, 0);

            }
            else if (PlayerPrefs.GetInt("VRType", 0) == 2)
            {
                PhotonNetwork.Instantiate("VivePlayer2", GameObject.Find("PlayerTwoLocation").transform.position, Quaternion.identity, 0);

            }
         

        }


    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetKey(KeyCode.W))
            {
                LocalVivePlayerInstance.MyCharacterController.Move(LocalVivePlayerInstance.transform.forward * Time.deltaTime *
                    LocalVivePlayerInstance.speeds);
            }
            if (Input.GetKey(KeyCode.S))
            {
                LocalVivePlayerInstance.MyCharacterController.Move(-LocalVivePlayerInstance.transform.forward * Time.deltaTime *
                    LocalVivePlayerInstance.speeds);
            }
            if (Input.GetKey(KeyCode.A))
            {
                LocalVivePlayerInstance.MyCharacterController.Move(-LocalVivePlayerInstance.transform.right * Time.deltaTime *
                    LocalVivePlayerInstance.speeds);
            }
            if (Input.GetKey(KeyCode.D))
            {
                LocalVivePlayerInstance.MyCharacterController.Move(LocalVivePlayerInstance.transform.right * Time.deltaTime *
                    LocalVivePlayerInstance.speeds);
            }

    }
}
