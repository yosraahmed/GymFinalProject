using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glovesAttach : MonoBehaviour
{
    public GameObject gloves;
    public Transform glovesLocation;
    public bool activeAttachment;
    public static glovesAttach Instanse;
    // Start is called before the first frame update
    void Start()
    {
        bool activeAttachment=true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        if (activeAttachment == true)
        {
            gloves.transform.parent = glovesLocation.transform;
            gloves.transform.localPosition = Vector3.zero;
            gloves.transform.localRotation = Quaternion.identity;
        }
        else
        {
            gloves.transform.parent = null;
            
        }
        

        // go.transform.SetParent(goWall.transform);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PunchingBag")
        {
            activeAttachment = false;

        }
    }
    private void OnTriggerEnter(Collider other1)
    {
        if (other1.tag=="PunchingBag")
        {
            activeAttachment = false;
            
        }
        
    }
    private void OnTriggerExit(Collider other2)
    {
        if (other2.tag == "PunchingBag")
        {
            activeAttachment = true;
        }
    }
}
