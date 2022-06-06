using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnBlock : MonoBehaviour
{
    public GameObject objectToAppear;
    public float range = 1;

    private void Update()
    {
        Vector3 direction = Vector3.down;
        Ray ray = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Player")
            {
                objectToAppear.gameObject.SetActive(true);
            }
        }

    }
}
