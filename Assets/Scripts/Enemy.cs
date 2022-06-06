using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Vector3 direction;
    [SerializeField]
    float speed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
 
    void Update()
    {
        rb.AddForce(direction * speed * Time.deltaTime, ForceMode.Impulse);
    }
}
