using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public GameObject particleBlue;
    public GameObject particleRed;
    public GameObject particleColor;
    public GameObject wrongCubeEffect;
    public Transform wrongCubeEffectTransform;
    
    //public Text ScourText;
    int zero = 0;
    int bluHit = 0;
    int redHit = 0;
    int colorHit = 0;
 
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("clr", 0);
        PlayerPrefs.SetInt("scorText", zero);
    }

    // Update is called once per frame
    void Update()
    {
        //ScourText.text = PlayerPrefs.GetInt("scorText", 0).ToString();
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BlueHit")
        {
            int crl = Random.Range(1, 3);
            if (crl==2)
            {
                PlayerPrefs.SetInt("clr", PlayerPrefs.GetInt("clr", 0) + 1);
            }
            PlayerPrefs.SetInt("Grade", PlayerPrefs.GetInt("Grade", 0) + 1);
            soundManager.instance.boxEffect();
            PlayerPrefs.SetInt("scorText", PlayerPrefs.GetInt("scorText", 0) + 1);
            Instantiate(particleBlue, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
        if (other.tag == "RedHit")
        {
            int crl = Random.Range(1, 3);
            if (crl == 2)
            {
                PlayerPrefs.SetInt("clr", PlayerPrefs.GetInt("clr", 0) + 1);
            }
            PlayerPrefs.SetInt("Grade", PlayerPrefs.GetInt("Grade", 0) + 1);
            soundManager.instance.CubeCrashSound();
            PlayerPrefs.SetInt("scorText", PlayerPrefs.GetInt("scorText", 0)+1);
            Instantiate(particleRed, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
        if (other.tag == "ColorHit")
        {
            int crl = Random.Range(1, 3);
            if (crl == 2)
            {
                PlayerPrefs.SetInt("clr", PlayerPrefs.GetInt("clr", 0) + 2);
            }
            PlayerPrefs.SetInt("Grade", PlayerPrefs.GetInt("Grade", 0) + 1);
            soundManager.instance.CubeCrashSound();
            PlayerPrefs.SetInt("scorText", PlayerPrefs.GetInt("scorText", 0) + 1);
            Instantiate(particleColor, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
        if (other.tag == "Squat1Hit")
        {
            soundManager.instance.wrongBallCrashSound();
            Instantiate(wrongCubeEffect, wrongCubeEffectTransform.transform.position, wrongCubeEffectTransform.transform.rotation);
            PlayerPrefs.SetInt("Grade", 0);
            PlayerPrefs.SetInt("GradeEffect1", 0);
            PlayerPrefs.SetInt("GradeEffect2", 0);
            PlayerPrefs.SetInt("GradeEffect3", 0);
            PlayerPrefs.SetInt("GradeEffect4", 0);
            PlayerPrefs.SetInt("scorText", PlayerPrefs.GetInt("scorText", 0) - 1);
            Destroy(other.gameObject);
        }

    }
}
