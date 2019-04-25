using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquatsMove : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position -= transform.forward * gameManager.instance.BulletSpeed * Time.deltaTime;
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

 
}
