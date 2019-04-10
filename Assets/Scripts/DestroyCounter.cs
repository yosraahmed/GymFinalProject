using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCounter : MonoBehaviour
{
    float timer =3;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            Destroy(gameObject);
        }
    }

   


}

