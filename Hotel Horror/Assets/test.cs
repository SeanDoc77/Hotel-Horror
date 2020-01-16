using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float hitDistance;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log(hit.collider.name + ", " + hit.distance);
            hitDistance = hit.distance;

            if (hit.collider.name == "PRE_DOO_Door_01_01" && hitDistance < 4.0f)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<Animation>().Play("openDoorNormal");
                }
            }
        }
    }
}