using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRooms : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("enter");
        foreach (Transform room in gameObject.transform.parent.transform)
        {
            if (room.transform.tag == "room")
            {
                room.gameObject.active = true;
            }
            if (room.transform.tag == "hallway")
            {
                room.gameObject.active = true;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("exit");
        foreach (Transform room in gameObject.transform.parent.transform)
        {
            if (room.transform.tag == "room")
            {
                room.gameObject.active = false;
            }
            if (room.transform.tag == "hallway")
            {
                room.gameObject.active = false;
            }
        }
    }
}
