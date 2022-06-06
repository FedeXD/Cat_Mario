using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishAppearSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip fish;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySound();
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(fish, 0.3f);
    }
}
