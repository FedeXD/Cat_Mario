using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBlock : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip block;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(block, 0.5f);
            StartCoroutine(destroyObject());         
        }
    }

    IEnumerator destroyObject()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
