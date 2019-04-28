using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxing : MonoBehaviour
{
    public int numberOfObjects;
    public int currentObjects;
    public GameObject objectToPlace;

    public float randomX;
    public float randomY;
    public float randomZ;
    private Renderer r;
    RaycastHit hit;
    void Start()
    {

        r = GetComponent<Renderer>();
        
    }

    void Update()
    {
        //print(r.bounds.min.x + "  " + r.bounds.max.x);
        //print(r.bounds.min.z + "  " + r.bounds.max.z);
        //randomX = Random.Range(-0.25f, 0.22f);
        randomX = Random.Range(r.bounds.min.x, r.bounds.max.x);
        //randomX = -0.5097054f;
        //randomZ = Random.Range(-0.4f, -0.25f);
        //randomY = Random.Range(0.8f, 1.5f);
        randomZ = Random.Range(r.bounds.min.z, r.bounds.max.z);
        randomY = Random.Range(r.bounds.min.y, r.bounds.max.y);
        //randomZ = -0.5097054f;

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(new Vector3(randomX, randomY , randomZ), Vector3.forward, out hit))
            {
                Instantiate(objectToPlace, hit.point, Quaternion.identity);
                currentObjects += 1;
            }
        }
    }
}
