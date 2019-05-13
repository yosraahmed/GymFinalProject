using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    void Start()
    {
         
    }

    void Update()
    {
        transform.Rotate(0, 0, 4);
        transform.position -= transform.forward * gameManagerPhoton.instance.BulletSpeed * Time.deltaTime;
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

 
}
