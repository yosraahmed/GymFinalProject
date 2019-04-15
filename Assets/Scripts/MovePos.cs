using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePos : MonoBehaviour
{
    public Text timemovetext;
    public float moveTime;
    public enum Movement
    {
        Idle,
        Walk,
    }
    public Movement currentState;
    //public bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        moveTime = 0;
        //currentState = Movement.Walk;
    }

    // Update is called once per frame
    void Update()
    {
        timemovetext.text = moveTime.ToString();
        if (moveTime>0)
        {
            moveTime -= Time.deltaTime;
        }
        else if (moveTime < 0)
        {
            moveTime = 0;

        }

        if (PlayerPrefs.GetInt("moving", 0) == 1 && moveTime < 1 )
        {
            moveTime ++;
        }

        if ( moveTime > 0 && Input.GetKey(KeyCode.Space))
        {
            currentState = Movement.Walk;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            currentState = Movement.Idle;
        }
        else if (moveTime == 0)
        {
            currentState = Movement.Idle;
        }
        //else if (PlayerPrefs.GetInt("moving", 0) == 1)
        //{
            
        //}
        
        switch (currentState)
        {
            case Movement.Idle:
                print("idle");
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                
                break;

            case Movement.Walk:
                print("walk");
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5);
                
                break;
            default:
                break;



        }
    }
    
}
