using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBoxing : MonoBehaviour 
     
{
    //private readonly Transform randomBullet;
    public GameObject randomBullet1;
    float randomtimer;
    public GameObject Newobject;
    float radius =0.1f ;
    int k = 0;
    // Start is called before the first frame update
    void Start()
    {
        randomtimer = -1;
    }

    // Update is called once per frame
    void Update()
    {


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
                (position.x + vector2.x ) 
                , 
                (position.y + 0 )
                ,
                (position.z + vector2.y) 
                )
                ;


            //Newobject = Instantiate(randomBullet1, position1, transform.rotation);
            //Newobject.transform.parent = gameObject.transform;
            //randomtimer = 1;

            if (position1.z < -4.5f)
            {
                ExplosionDamage(position1, radius);
                if (Newobject == null)
                {
                    Newobject = Instantiate(randomBullet1, position1, transform.rotation);
                    Newobject.transform.parent = gameObject.transform;
                    randomtimer = 1;
                }
                else
                if (k == 0)
                {
                    Newobject = Instantiate(randomBullet1, position1, transform.rotation);
                    Newobject.transform.parent = gameObject.transform;
                    randomtimer = 1;
                }

                else
                { randomtimer = -1; }

            }
            else
            { randomtimer = -1; }




            //Vector2 randPos = Random.insideUnitCircle * 5;
            //randomBullet1.transform.position += new Vector3(randPos.x, 0, randPos.y);

            //Alternatively look at a thing
            // randomBullet1.transform.eulerAngles = new Vector3(0, Quaterion.LookAt(Vector3.zero /* or anything else you wanna look at*/).eulerAngles.y, 0);

            //var myNewSmoke = Instantiate(poisonSmoke, Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //myNewSmoke.transform.parent = gameObject.transform;




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





        //private Vector3 RandomPointOnCircleEdge(float radius)
        //{
        //    var vector2 = Random.insideUnitCircle.normalized * radius;
        //    return new Vector3(vector2.x, 0, vector2.y);
        //}
    }
