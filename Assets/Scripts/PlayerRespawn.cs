using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject player1;
    public Transform player1Location;
    public Transform player2Location;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Master", 0) == 1)
        {
            //PlayerPrefs.SetInt("Playerlocation", 1);
            PhotonNetwork.Instantiate(this.player1.name, player1Location.transform.position, Quaternion.identity, 0);
            PlayerPrefs.SetInt("Master", 0);
        }
        else
        {
            PhotonNetwork.Instantiate(this.player1.name, player2Location.transform.position, Quaternion.identity, 0);
            //PlayerPrefs.SetInt("Playerlocation", 0);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
