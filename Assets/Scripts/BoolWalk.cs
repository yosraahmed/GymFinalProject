using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolWalk : MonoBehaviour
{
    MovePos newState;
    // Start is called before the first frame update
    void Start()
    {
        newState = GetComponent<MovePos>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other1)
    {
        if (other1.tag == "Moves")
        {
            PlayerPrefs.SetInt("moving", 0);
            //newState.currentState = MovePos.Movement.Walk;
           // newState.currentState = MovePos.Movement.Idle;
            // move = false;
            //PlayerPrefs.SetInt("moving", 0);
        }
        //else
        //{
        //    newState.currentState = MovePos.Movement.Walk;
        //    // move = true;
        //    //PlayerPrefs.SetInt("moving", 1);
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Moves")
        {
            PlayerPrefs.SetInt("moving", 1);
            //newState.currentState = MovePos.Movement.Walk;
            // move = false;
            //PlayerPrefs.SetInt("moving", 0);
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
