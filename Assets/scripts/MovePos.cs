using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePos : MonoBehaviour
{
    public bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("moving", 0) == 1)
        {
            print("moving");
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5);
        }
        else 
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        
    }
    
}
