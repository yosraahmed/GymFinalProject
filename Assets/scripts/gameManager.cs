using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour

{
    public Transform SquatsPoint1;
    public GameObject Squat1;
    public Transform SquatsPoint2;
    public GameObject Squat2;
    public Transform SquatsPoint3;
    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;
    public float BulletSpeed = 20;
    public float Bullettimer = 2;
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

        if (timer < 0)
        {
            Vector3 position = new Vector3(
                Random.Range(transform.position.x + Width, transform.position.x - Width),
                Random.Range(transform.position.y + Hight, transform.position.y),
                transform.position.z);
                
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
            }
            else if (Bullettype == 5)
            {
                Instantiate(Squat2, SquatsPoint2.transform.position, SquatsPoint2.transform.rotation);
            }
            else if (Bullettype == 6)
            {
                Instantiate(Squat1, SquatsPoint3.transform.position, SquatsPoint3.transform.rotation);
            }


            timer = Bullettimer;
            BulletsNum += 1;
        }

        timer -= Time.deltaTime;

    }
}
