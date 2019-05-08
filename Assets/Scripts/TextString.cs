using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextString : MonoBehaviour
{
    //public GameObject Textstr;

    
    //Text text1;
    string txt;
    public Text myText;

    void Awake()
    {
       
    }


    void Start()
    {
        //myText = GameObject.Find("IntText").GetComponent<Text>();
      
    }

    // Update is called once per frame
    void Update()
    { 
        txt = RespawnBoxing.instance.Itxt.ToString();
        //myText.text = txt;

    }
}
