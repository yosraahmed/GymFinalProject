using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBullet : MonoBehaviour
{
    
    //public float BulletSpeed = 20;
    void Start()
    {
        //Smoke = FindObjectOfType<ParticleSystem>();
    }

    void Update()
    {
        transform.Rotate(0, 0, 4);
        transform.position -= transform.forward * GameManager.instance.BulletSpeed * Time.deltaTime;
        //if ( transform.position.z < -30)  Invoke("DestroyBullet", 2);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

 
}
