using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableStairways : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        foreach (Transform room in gameObject.transform.parent.transform)
        {
            if (room.transform.tag == "stairway")
            {
                room.gameObject.active = true;
            }
        }
        Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerExit(Collider collision)
    {
        foreach (Transform room in gameObject.transform.parent.transform)
        {
            if (room.transform.tag == "stairway")
            {
                room.gameObject.active = false;
            }
        }
    }
}
