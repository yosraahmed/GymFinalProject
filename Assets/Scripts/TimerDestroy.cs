using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDestroy : MonoBehaviour
{
    //float timer = 5;
    float timer = RespawnBoxing.instance.TimeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <=0)
        {
            Destroy(this.gameObject);
        }
    }
}
