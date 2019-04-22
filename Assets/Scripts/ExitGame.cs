using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameObject pointerOnOff;
    public GameObject inputOnOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Start))
        {
                pointerOnOff.SetActive(true);
                inputOnOff.SetActive(true);
        }
        else
        {
            pointerOnOff.SetActive(false);
            inputOnOff.SetActive(false);
        }
        //if (OVRInput.GetUp(OVRInput.Button.Start))
        //{
        //}
    }
}
