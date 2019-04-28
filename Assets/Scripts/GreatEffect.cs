using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatEffect : MonoBehaviour
{
    public Transform gradeEffectLocation;
    public ParticleSystem gradeEffect11;
    public GameObject gradeEffect1;
    public GameObject gradeEffect2;
    public GameObject gradeEffect3;
    public GameObject gradeEffect4;
    bool aciveEffect;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Grade", 0);
        PlayerPrefs.SetInt("GradeEffect1", 0);
    }

    // Update is called once per frame
    void Update()
    {
        print("grade" + PlayerPrefs.GetInt("Grade", 0) );
        if (PlayerPrefs.GetInt("Grade", 0) == 5 && PlayerPrefs.GetInt("GradeEffect1", 0) == 0)
        {
            Instantiate(gradeEffect1, gradeEffectLocation.transform.position, gradeEffectLocation.transform.rotation);
            PlayerPrefs.SetInt("GradeEffect1", 1);
        }
        if (PlayerPrefs.GetInt("Grade", 0) == 15 && PlayerPrefs.GetInt("GradeEffect2", 0) == 0)
        {
            Instantiate(gradeEffect2, gradeEffectLocation.transform.position, gradeEffectLocation.transform.rotation);
            PlayerPrefs.SetInt("GradeEffect2", 1);
        }
        if (PlayerPrefs.GetInt("Grade", 0) == 25 && PlayerPrefs.GetInt("GradeEffect3", 0) == 0)
        {
            Instantiate(gradeEffect3, gradeEffectLocation.transform.position, gradeEffectLocation.transform.rotation);
            PlayerPrefs.SetInt("GradeEffect3", 1);
        }
        if (PlayerPrefs.GetInt("Grade", 0) == 40 && PlayerPrefs.GetInt("GradeEffect4", 0) == 0)
        {
            Instantiate(gradeEffect4, gradeEffectLocation.transform.position, gradeEffectLocation.transform.rotation);
            PlayerPrefs.SetInt("GradeEffect4", 1);
        }
    }
}
