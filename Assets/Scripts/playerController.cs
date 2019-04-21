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
        //PlayerPrefs.SetInt("scorText", bluHit + redHit + colorHit);
        ScourText.text = PlayerPrefs.GetInt("scorText", 0).ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BlueHit")
        {
            soundManager.instance.CubeCrashSound();
            bluHit += 1;
            Instantiate(particleBlue, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);


        }
        if (other.tag == "RedHit")
        {
            soundManager.instance.CubeCrashSound();
            PlayerPrefs.SetInt("scorText", PlayerPrefs.GetInt("scorText", 0)+1);
            //redHit += 1;
            Instantiate(particleRed, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
        if (other.tag == "ColorHit")
        {
            soundManager.instance.CubeCrashSound();
            PlayerPrefs.SetInt("scorText", PlayerPrefs.GetInt("scorText", 0) + 1);
            //colorHit += 1;
            Instantiate(particleColor, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
        if (other.tag == "Squat1Hit")
        {
            soundManager.instance.CubeCrashSound();
            PlayerPrefs.SetInt("scorText", PlayerPrefs.GetInt("scorText", 0) - 1);
            //colorHit -= 1;
            Destroy(other.gameObject);
        }

        //}
        //if (other.tag == "RedHit")
        //{
        //    soundManager.instance.CubeCrashSound();
        //    redHit += 1;
        //    Instantiate(particleRed, other.transform.position, other.transform.rotation);
        //    Destroy(other.gameObject);
        //}
        //if (other.tag == "ColorHit")
        //{
        //    soundManager.instance.CubeCrashSound();
        //    colorHit += 1;
        //    Instantiate(particleColor, other.transform.position, other.transform.rotation);
        //    Destroy(other.gameObject);
        //}

    }
}
