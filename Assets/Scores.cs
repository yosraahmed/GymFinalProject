using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public Text ScourText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string tempTimer = string.Format("{0:D3}", PlayerPrefs.GetInt("scorText", 0));
        ScourText.text = tempTimer;
    }
}
