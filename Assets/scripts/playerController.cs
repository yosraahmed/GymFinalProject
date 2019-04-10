using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject particleBlue;
    public GameObject particleRed;
    public GameObject particleColor;

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
        if (other.tag== "BlueHit")
        {
            Destroy(other.gameObject);
            Instantiate(particleBlue, transform.position, transform.rotation);
        }
        if (other.tag == "RedHit")
        {
            Destroy(other.gameObject);
            Instantiate(particleRed, transform.position, transform.rotation);
        }
        if (other.tag == "ColorHit")
        {
            Destroy(other.gameObject);
            Instantiate(particleColor, transform.position, transform.rotation);
        }
    }
}
