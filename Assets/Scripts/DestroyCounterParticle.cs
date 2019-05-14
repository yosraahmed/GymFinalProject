using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCounterParticle : MonoBehaviour
{
    float timer =3;
    // Start is called before the first frame update
    void Start()
    {
        if (RespawnBoxing.instance == null)
        {
            timer = 3;
        }
       // timer = 3;
       else
        timer = RespawnBoxing.instance.TimeDestroy;
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

