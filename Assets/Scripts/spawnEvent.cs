using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEvent : MonoBehaviour
{
    public GameObject objectToAppear;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectToAppear.gameObject.SetActive(true);
        }
    }
}
