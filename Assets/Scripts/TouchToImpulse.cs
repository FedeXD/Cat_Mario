using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToImpulse : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public float range = 1;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void Update()
    {
        Vector3 direction = Vector3.down;
        Ray ray = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if(Physics.Raycast(ray, out RaycastHit hit, range))
        {
            if(hit.collider.tag == "Player")
            {
                rb.AddForce(Vector3.up * speed);
                StartCoroutine(StopGoingUp());
                rb.constraints = RigidbodyConstraints.FreezePositionX;
                rb.constraints = RigidbodyConstraints.FreezePositionZ;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Player")
    //    {
            
    //    }
    //}

    IEnumerator StopGoingUp()
    {
        yield return new WaitForSeconds(0.5f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    

}
