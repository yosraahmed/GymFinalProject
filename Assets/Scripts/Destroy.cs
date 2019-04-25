using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BlueHit")
        {
            PlayerPrefs.SetInt("Grade", 0);
            Destroy(other.gameObject);
        }
        if (other.tag == "RedHit")
        {
            PlayerPrefs.SetInt("Grade", 0);
            Destroy(other.gameObject);
        }
        if (other.tag == "ColorHit")
        {
            PlayerPrefs.SetInt("Grade", 0);
            Destroy(other.gameObject);
        }
        if (other.tag == "Squat1Hit")
        {
            Destroy(other.gameObject);
        }
       

    }


}

