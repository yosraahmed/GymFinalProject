using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject player1;
    public Transform player1Location;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Playerlocation", 0) == 0)
        {
            PlayerPrefs.SetInt("Playerlocation", 1);
            PhotonNetwork.Instantiate(this.player1.name, new Vector3(0f, 7f, 0f), Quaternion.identity, 0);
        }
        else
        {
            PhotonNetwork.Instantiate(this.player1.name, new Vector3(3f, 7f, 3f), Quaternion.identity, 0);
            PlayerPrefs.SetInt("Playerlocation", 0);
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
