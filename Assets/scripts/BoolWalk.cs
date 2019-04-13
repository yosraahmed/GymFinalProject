using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolWalk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other1)
    {
        if (other1.tag == "Moves")
        {
            // move = false;
            PlayerPrefs.SetInt("moving", 0);
        }
        else
        {
            // move = true;
            PlayerPrefs.SetInt("moving", 1);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Moves")
    //    {
    //        // move = false;
    //        PlayerPrefs.SetInt("moving", 0);
    //    }
    //    else 
    //    {
    //        // move = true;
    //        PlayerPrefs.SetInt("moving", 1);
    //    }
    //}
}
