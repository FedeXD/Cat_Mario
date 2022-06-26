using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    CapsuleCollider capCollider;
    AudioSource audioSource;
    public AudioClip jump;
    public AudioClip death;
    public Animator animator;
    float speed = 10f;
    float jumpForce =10f;
    float horizontalInput;
    bool isOnGround = true;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capCollider = GetComponent<CapsuleCollider>();
        audioSource = GetComponent<AudioSource>();
        animator.SetBool("isJumping", false);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.AddRelativeForce(Vector3.left * horizontalInput * speed * Time.deltaTime, ForceMode.Impulse);
        animator.SetBool("isRunning", Input.GetAxis("Horizontal") != 0);
        if(Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
            isOnGround = false;
            audioSource.PlayOneShot(jump, 0.5f);    
        }  
    }

    private void OnCollisionEnter(Collision collision)
    {
       isOnGround = true;
        animator.SetBool("isJumping", false);
        if (collision.gameObject.CompareTag("Enemy"))
       {
            capCollider.enabled = false;
            rb.AddForce(Vector3.up * 20, ForceMode.Impulse);
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            StartCoroutine(StopGoingUp());
            GameObject.Find("Music").GetComponent<AudioSource>().enabled = false;
            audioSource.PlayOneShot(death);
       }
    }

    IEnumerator StopGoingUp()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(GetComponent<PlayerController>());
    }
}
