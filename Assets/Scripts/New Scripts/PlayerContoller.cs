using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public static PlayerContoller Instance;

    public MyPlayer LocalPlayerInstance { get; set; }

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
            PhotonNetwork.Instantiate("VivePlayer", GameObject.Find("VivePlayerSpwanPoint").transform.position, Quaternion.identity);
        else
            PhotonNetwork.Instantiate("RedPlayer", GameObject.Find("RedSpwanPoint").transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            LocalPlayerInstance.MyCharacterController.Move(LocalPlayerInstance.transform.forward * Time.deltaTime *
                LocalPlayerInstance.speeds);
        }
        if (Input.GetKey(KeyCode.S))
        {
            LocalPlayerInstance.MyCharacterController.Move(-LocalPlayerInstance.transform.forward * Time.deltaTime *
                LocalPlayerInstance.speeds);
        }
        if (Input.GetKey(KeyCode.A))
        {
            LocalPlayerInstance.MyCharacterController.Move(-LocalPlayerInstance.transform.right * Time.deltaTime *
                LocalPlayerInstance.speeds);
        }
        if (Input.GetKey(KeyCode.D))
        {
            LocalPlayerInstance.MyCharacterController.Move(LocalPlayerInstance.transform.right * Time.deltaTime * 
                LocalPlayerInstance.speeds);
        }
    }
}
