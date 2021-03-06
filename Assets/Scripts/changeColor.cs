using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    public Material[] material;
    Renderer render;
    public float range = 1;
    AudioSource audioSource;
    public AudioClip coin;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        render = GetComponent<Renderer>();
        render.enabled = true;
        render.sharedMaterial = material[0];
    }

    private void Update()
    {
        Vector3 direction = Vector3.down;
        Ray ray = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Player")
            {
                render.sharedMaterial = material[1];
                PlaySound();
            }
        }
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(coin, 0.2f);
    }

    
}
