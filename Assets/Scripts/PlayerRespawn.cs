using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject player1;
    public Transform player1Location;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(player1.gameObject.name, player1Location.transform.position, player1Location.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
