using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemAppearsSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip item;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySound();
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(item, 1.0f);
    }
}
