using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDestroy : MonoBehaviour
{
    //float timer = 5;
    float timer = 0;
    // Start is called before the first frame update

    void Start()
    {
        timer = RespawnBoxing.instance.TimeDestroy;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <=0)
        {
            
            playerControllerBoxing.instance.i=0;
            PlayerPrefs.SetInt("Box1Type", 0);
            PlayerPrefs.SetInt("Box2Type", 0);
            PlayerPrefs.SetInt("Box3Type", 0);
            PlayerPrefs.SetInt("Box4Type", 0);
            Destroy(this.gameObject);
        }
    }
}
