using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour

{
    public Transform SquatsPoint1;
    public Transform SquatsPoint11;
    public GameObject Squat1;
    public Transform SquatsPoint2;
    public Transform SquatsPoint22;
    public GameObject Squat2;
    public Transform SquatsPoint3;
    public Transform SquatsPoint33;
    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;
    public float BulletSpeed ;
    public float Bullettimer ;
    public float Width = 0.5f;
    public float Hight = 0.5f;



    public static gameManager instance;
    float timer;
    float BulletsNum; //Number of Bullets Greating

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        timer = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("EasySquat", 0)==1)
        {
            BulletSpeed = 20;
            Bullettimer = 2;
        }
        else if (PlayerPrefs.GetInt("NormalSquat", 0) == 1)
        {
            BulletSpeed = 30;
            Bullettimer = 1.2f;
        }
        else if (PlayerPrefs.GetInt("HardSquat", 0) == 1)
        {
            BulletSpeed = 30;
            Bullettimer = 0.7f;
        }

        if (timer < 0)
        {
            Vector3 position = new Vector3(
                Random.Range(transform.position.x + Width, transform.position.x - Width),
                Random.Range(transform.position.y + Hight, transform.position.y),
                transform.position.z);
            int bullettype2 = Random.Range(1,4);
            int Bullettype = Random.Range(1, 7);
            if (Bullettype == 1)
            {
                Instantiate(Bullet1, position, transform.rotation);
            }
            else if (Bullettype == 2)
            {
                Instantiate(Bullet2, position, transform.rotation);
            }
            else if (Bullettype == 3)
            {
                Instantiate(Bullet3, position, transform.rotation);
            }
            else if (Bullettype == 4)
            {
                Instantiate(Squat1, SquatsPoint1.transform.position, SquatsPoint1.transform.rotation);
                Instantiate(Bullet2, SquatsPoint11.transform.position, SquatsPoint11.transform.rotation);
            }
            else if (Bullettype == 5)
            {
                Instantiate(Squat2, SquatsPoint2.transform.position, SquatsPoint2.transform.rotation);
                Instantiate(Bullet3, SquatsPoint22.transform.position, SquatsPoint22.transform.rotation);
            }
            else if (Bullettype == 6)
            {
                Instantiate(Squat1, SquatsPoint3.transform.position, SquatsPoint3.transform.rotation);
                Instantiate(Bullet1, SquatsPoint33.transform.position, SquatsPoint33.transform.rotation);
            }


            timer = Bullettimer;
            BulletsNum += 1;
        }

        timer -= Time.deltaTime;

    }
}
