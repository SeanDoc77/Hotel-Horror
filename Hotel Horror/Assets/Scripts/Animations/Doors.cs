using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public float hitDistance;

    // initialize door status - false = closed
    public bool open = false; 
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log(hit.collider.name + ", " + hit.distance);
            hitDistance = hit.distance;

            // if ((hit.collider.name == "Handle" || hit.collider.name == "Door") && hitDistance < 4.0f)
            if (hit.collider.name == "PRE_DOO_Door_01_01" && hitDistance < 4.0f)
            {
                if (!hit.collider.GetComponent<Animation>().isPlaying)
                {
                    // door is closed, press e to open door
                    if (!open)
                    {
                        if (Input.GetKeyDown(KeyCode.E) && (Input.GetKey(KeyCode.LeftShift)))
                        {
                            hit.collider.GetComponent<Animation>().Play("openDoorFast");
                            open = true;
                        }
                        else if (Input.GetKeyDown(KeyCode.E))
                        {
                            hit.collider.GetComponent<Animation>().Play("openDoorNormal");
                            open = true;
                        }
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            hit.collider.GetComponent<Animation>().Play("closeDoorNormal");
                            open = false;
                        }
                    }
                }
            }
        }
    }
}