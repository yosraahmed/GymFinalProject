using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingTestBack : MonoBehaviour
{
    public bool activeAttachment;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         //rb.constraints = RigidbodyConstraints.FreezeAll;

        if (activeAttachment == true)
        {
            rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1 * Time.deltaTime);
            //Vector3 move = new Vector3(0, 0, -1) * Time.deltaTime;
            //rb.MovePosition(move);
            //rb.MovePosition(transform.position - transform.forward * Time.deltaTime);

            
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    private void OnTriggerEnter(Collider other1)
    {
        if (other1.tag == "PunchingBag")
        {
           
            activeAttachment = true;

        }

    }
    private void OnTriggerExit(Collider other2)
    {
        if (other2.tag == "PunchingBag")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            //rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            activeAttachment = false;
        }
    }
}
