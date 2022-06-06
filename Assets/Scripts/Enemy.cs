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
    AudioSource audioSource;
    public AudioClip stomp;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
 
    void Update()
    {
        rb.AddForce(direction * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(stomp, 0.5f);
            
            StartCoroutine(destroyObject());
        }
    }

    IEnumerator destroyObject()
    {
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }


}
