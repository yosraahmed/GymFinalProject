using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnBoxing : MonoBehaviour

{
    //private readonly Transform randomBullet;
    public GameObject randomBullet1;
    public float randomtimer;
    public GameObject Newobject;
    public float radius = 0.07f;
    public float speed;
    public float TimeDestroy =5 ;
    public List<GameObject> allBullet;
    public Text ScourText;
    int ntxt = 0;
     public int Itxt = 0;
     int JLOOP = 0;
     //int k;
    public static RespawnBoxing instance;


    List<GameObject> numbers;
    private void Awake()
    {
        if (instance == null) instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("boxingscorText", 0);
        randomtimer = -speed;

    }

    // Update is called once per frame
    void Update()
    {
        
        ScourText.text = PlayerPrefs.GetInt("boxingscorText", 0).ToString();
        JLOOP = 4;
        speed = 51f;
        TimeDestroy = 50f;
        //if (playerControllerBoxing.instance.ddd == true)
        //{

        //    allBullet.Clear();
        //    playerControllerBoxing.instance.ddd = false;

        //}


        if (PlayerPrefs.GetInt("EasyBoxing", 0) == 1)
        {
            speed = 3.12f;
            JLOOP =2;
           TimeDestroy = 3.1f;
        }
        else if (PlayerPrefs.GetInt("NormalBoxing", 0) == 1)
        {
            speed = 2.92f;
            JLOOP = 3;
            TimeDestroy = 2.9f;
        }
        else if (PlayerPrefs.GetInt("HardBoxing", 0) == 1)
        {
            speed = 2.72f;
            JLOOP = 4;
            TimeDestroy = 2.7f;
        }


        if (randomtimer < 0)
        {
            Itxt = 0;
            for (int J = 0; J < JLOOP; J++)
                {
                    bool test = false;

                    while (!test)
                    {
                    Vector3 position = new Vector3(
                            Random.Range(transform.position.x + 0, transform.position.x + 0),
                            Random.Range((transform.position.y + (transform.localScale.y - .5f)),
                            (transform.position.y - (transform.localScale.y - .5f))),
                            transform.position.z);
                    var vector2 = Random.insideUnitCircle.normalized * ((transform.localScale.y / 2.5f) - 0);
                    Vector3 position1 = new Vector3((position.x + vector2.x), (position.y + 0), (position.z + vector2.y));
                        if (position1.z < -4.7f)
                        {
                            test = ExplosionDamage(position1, radius);
                        }
                    }
                }

        }

        randomtimer -= Time.deltaTime;
    }






    void GreatNewObject(Vector3 Pos)
    {
        Newobject = Instantiate(randomBullet1, Pos, transform.rotation);
        Newobject.transform.parent = gameObject.transform;
        allBullet.Add(Newobject);
        // numbers.Add(Newobject);
        randomtimer = speed;
        ntxt = ntxt + 1;
        Itxt = Itxt + 1;
        // Newobject.GetComponent<TimerDestroy>().myNumber.text  = ntxt.ToString();
        //GetComponent<TextString>().myText.text = ntxt.ToString();
        //Newobject.GetComponentInChildren<Canvas>().GetComponentInChildren<Text>().text = ntxt.ToString();
        Newobject.GetComponentInChildren<Canvas>().GetComponent<TextString>().myText.text = Itxt.ToString();
        //string txt = GetComponentInChildren<Canvas>().GetComponent<TextString>().myText.text.ToString();
    }

    Collider[] hitColliders;
    bool ExplosionDamage(Vector3 center, float radius)
    {
        hitColliders = Physics.OverlapSphere(center, radius);

        foreach (Collider item in hitColliders)
        {
            if (item.tag == "RedHit")
                return false;
        }

        GreatNewObject(center);

        return true;
    }

}
