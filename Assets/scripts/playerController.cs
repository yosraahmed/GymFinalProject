using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public GameObject particleBlue;
    public GameObject particleRed;
    public GameObject particleColor;
    public Text ScourText;
    int zero = 0;
    int bluHit = 0;
    int redHit = 0;
    int colorHit = 0;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("scorText", zero);


    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("scorText", bluHit + redHit + colorHit);
        ScourText.text = PlayerPrefs.GetInt("scorText", 0).ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag== "BlueHit")
        {
            bluHit += 1;
            Destroy(other.gameObject);
            Instantiate(particleBlue, transform.position, transform.rotation);
        }
        if (other.tag == "RedHit")
        {
            redHit += 1;
            Destroy(other.gameObject);
            Instantiate(particleRed, transform.position, transform.rotation);
        }
        if (other.tag == "ColorHit")
        {
            colorHit += 1;
            Destroy(other.gameObject);
            Instantiate(particleColor, transform.position, transform.rotation);
        }
    }
}
