using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    CapsuleCollider capCollider;
    float speed = 10f;
    float jumpForce =10f;
    float horizontalInput;
    bool isOnGround = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capCollider = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.AddRelativeForce(Vector3.right * horizontalInput * speed * Time.deltaTime, ForceMode.Impulse);
        if(Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       isOnGround = true;
       if (collision.gameObject.CompareTag("Enemy"))
       {
            capCollider.enabled = false;
            rb.AddForce(Vector3.up * 20, ForceMode.Impulse);
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
