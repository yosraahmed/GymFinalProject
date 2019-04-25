using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBoxing : MonoBehaviour

{
    //private readonly Transform randomBullet;
    public GameObject randomBullet1;
    public float randomtimer;
    public GameObject Newobject;
    float radius = 0.1f;
    int k = 0;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        randomtimer = -speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("EasyBoxing", 0) == 1)
        {
            speed = 1f;
        }
        else if (PlayerPrefs.GetInt("NormalBoxing", 0) == 1)
        {
            speed = 0.5f;
        }
        else if (PlayerPrefs.GetInt("HardBoxing", 0) == 1)
        {
            speed = 0.1f;
        }


        if (randomtimer < 0)

        {
            Vector3 position = new Vector3(
                Random.Range(transform.position.x + 0, transform.position.x + 0),
                Random.Range(
                    (transform.position.y + (transform.localScale.y - .5f))
                    ,
                    (transform.position.y - (transform.localScale.y - .5f))
                    )
                    ,
                    transform.position.z
                    );

            var vector2 = Random.insideUnitCircle.normalized * ((transform.localScale.y / 2) - 0);

            Vector3 position1 = new Vector3(
                (position.x + vector2.x)
                ,
                (position.y + 0)
                ,
                (position.z + vector2.y)
                )
                ;

            if (position1.z < -4.5f)
            {
                ExplosionDamage(position1, radius);
                if (Newobject == null)
                {
                    Newobject = Instantiate(randomBullet1, position1, transform.rotation);
                    Newobject.transform.parent = gameObject.transform;
                    randomtimer = speed;
                }
                else
                if (k == 0)
                {
                    Newobject = Instantiate(randomBullet1, position1, transform.rotation);
                    Newobject.transform.parent = gameObject.transform;
                    randomtimer = speed;
                }

                else
                { randomtimer = -speed; }

            }
            else
            { randomtimer = -speed; }


        }

        randomtimer -= Time.deltaTime;

    }




    Collider[] hitColliders;
    void ExplosionDamage(Vector3 center, float radius)
    {
        hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        k = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "RedHit")
            {
                k = 1;
            }
            i++;
        }

    }

}
