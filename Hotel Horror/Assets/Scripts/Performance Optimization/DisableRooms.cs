using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRooms : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        foreach (Transform room in gameObject.transform)
        {
            if (room.transform.tag == "room")
            {
                room.gameObject.active = true;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        foreach (Transform room in gameObject.transform)
        {
            if (room.transform.tag == "room")
            {
                room.gameObject.active = false;
            }
        }
    }
}
