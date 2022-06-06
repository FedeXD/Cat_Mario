using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSide : MonoBehaviour
{
    public float min;
    public float max;
    public float minPos;
    public float maxPos;
    public float speed;
    
    void Start()
    { 
        min = transform.position.x - minPos;
        max = transform.position.x + maxPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = sideToSide(); 
    }

    Vector3 sideToSide()
    {
        return new Vector3(Mathf.PingPong(Time.time * speed, max - min) + min, transform.position.y, transform.position.z);
    }
}
