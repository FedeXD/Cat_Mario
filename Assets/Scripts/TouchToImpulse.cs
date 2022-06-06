using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToImpulse : MonoBehaviour
{
    public float dir;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            rb.AddForce(Vector3.up * dir);
            StartCoroutine(StopGoingUp());
        }
    }

    IEnumerator StopGoingUp()
    {
        yield return new WaitForSeconds(0.5f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
