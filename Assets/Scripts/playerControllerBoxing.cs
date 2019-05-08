using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControllerBoxing : MonoBehaviour
{
    public GameObject particleBlue;
    public GameObject particleRed;
    public GameObject particleColor;
    public GameObject wrongCubeEffect;
    public Transform wrongCubeEffectTransform;
    public Text text1;
    public int textt;
    int i;
    


    //public Text ScourText;
    int zero = 0;
    int bluHit = 0;
    int redHit = 0;
    int colorHit = 0;

    public static playerControllerBoxing instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        PlayerPrefs.SetInt("Box1Type", 0);
        PlayerPrefs.SetInt("Box2Type", 0);
        PlayerPrefs.SetInt("Box3Type", 0);
        PlayerPrefs.SetInt("Box4Type", 0);
        PlayerPrefs.SetInt("clr", 0);
        PlayerPrefs.SetInt("scorText", zero);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerPrefs.GetInt("EasyBoxing", 0) == 1)
        {
            if (PlayerPrefs.GetInt("Box1Type", 0) == 1 && PlayerPrefs.GetInt("Box2Type", 0) == 1 )
            {
                PlayerPrefs.SetInt("boxingscorText", PlayerPrefs.GetInt("boxingscorText", 0) + 2);
                PlayerPrefs.SetInt("Box1Type", 0);
                PlayerPrefs.SetInt("Box2Type", 0);
                PlayerPrefs.SetInt("Box3Type", 0);
                PlayerPrefs.SetInt("Box4Type", 0);
                i = 0;
            }
        }
        else if (PlayerPrefs.GetInt("NormalBoxing", 0) == 1)
        {
            if (PlayerPrefs.GetInt("Box1Type", 0) == 1 && PlayerPrefs.GetInt("Box2Type", 0) == 1 && PlayerPrefs.GetInt("Box3Type", 0) == 1 )
            {
                PlayerPrefs.SetInt("boxingscorText", PlayerPrefs.GetInt("boxingscorText", 0) + 3);
                PlayerPrefs.SetInt("Box1Type", 0);
                PlayerPrefs.SetInt("Box2Type", 0);
                PlayerPrefs.SetInt("Box3Type", 0);
                PlayerPrefs.SetInt("Box4Type", 0);
                i = 0;
            }
        }
        else if (PlayerPrefs.GetInt("HardBoxing", 0) == 1)
        {
            if (PlayerPrefs.GetInt("Box1Type", 0) == 1 && PlayerPrefs.GetInt("Box2Type", 0) == 1 && PlayerPrefs.GetInt("Box3Type", 0) == 1 && PlayerPrefs.GetInt("Box4Type", 0) == 1)
            {
                PlayerPrefs.SetInt("boxingscorText", PlayerPrefs.GetInt("boxingscorText", 0) + 4);
                PlayerPrefs.SetInt("Box1Type", 0);
                PlayerPrefs.SetInt("Box2Type", 0);
                PlayerPrefs.SetInt("Box3Type", 0);
                PlayerPrefs.SetInt("Box4Type", 0);
                i = 0;
            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "BlueHit")
        //{
        //    int crl = Random.Range(1, 3);
        //    if (crl==2)
        //    {
        //        PlayerPrefs.SetInt("clr", PlayerPrefs.GetInt("clr", 0) + 1);
        //    }
        //    PlayerPrefs.SetInt("Grade", PlayerPrefs.GetInt("Grade", 0) + 1);
        //    soundManager.instance.boxEffect();
        //    PlayerPrefs.SetInt("scorText", PlayerPrefs.GetInt("scorText", 0) + 1);
        //    Instantiate(particleBlue, other.transform.position, other.transform.rotation);
        //    Destroy(other.gameObject);
        //}

        if (other.tag == "RedHit")
        {
            text1.text = other.GetComponentInChildren<TextString>().myText.text.ToString();
            int textt = int.Parse(text1.text);
            i += 1;
            if (textt == i )
            {
                Destroy(other.gameObject);
                Instantiate(particleBlue, other.transform.position, other.transform.rotation);
                if (i == 1)
                {
                    PlayerPrefs.SetInt("Box1Type", 1);
                }
                if (i == 2)
                {
                    PlayerPrefs.SetInt("Box2Type", 1);
                }
                if (i == 3)
                {
                    PlayerPrefs.SetInt("Box3Type", 1);
                }
                if (i == 4)
                {
                    PlayerPrefs.SetInt("Box4Type", 1);
                }
                //foreach (var e in RespawnBoxing.instance.allBullet)
                //{
                //    Destroy(e);
                //}
                //RespawnBoxing.instance.allBullet.Clear();

                ////for (int J = 0; J < RespawnBoxing.instance.allBullet.Count; J++)
                ////{
                ////    Destroy(RespawnBoxing.instance.allBullet[J]);
                ////    RespawnBoxing.instance.allBullet.Remove(J);
                ////}
                //////RespawnBoxing.instance.allBullet = null;\
                ////RespawnBoxing.instance.allBullet =;
            }
            else
            {
                foreach (var e in RespawnBoxing.instance.allBullet)
                {
                    Destroy(e);
                    //Instantiate(particleBlue, e.transform.position, e.transform.rotation);
                }
                i = 0;
                RespawnBoxing.instance.allBullet.Clear();
                PlayerPrefs.SetInt("Box1Type", 0);
                PlayerPrefs.SetInt("Box2Type", 0);
                PlayerPrefs.SetInt("Box3Type", 0);
                PlayerPrefs.SetInt("Box4Type", 0);

            }

        }
        //if (other.tag == "Box2")
        //{
        //    PlayerPrefs.SetInt("Box2Type", 1);
        //}
        //if (other.tag == "Box3")
        //{
        //    PlayerPrefs.SetInt("Box3Type", 1);
        //}
        //if (other.tag == "Box4")
        //{
        //    PlayerPrefs.SetInt("Box4Type", 1);
        //}
        

    }
}
