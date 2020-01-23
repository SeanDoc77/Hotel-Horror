using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class OnlineDisableRooms : NetworkBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        GameObject localObject = collision.gameObject;
        if (localObject.GetComponent<CharacterController>() && localObject.transform.GetChild(0).GetComponent<Camera>().enabled == true)
        {
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
    }

    private void OnTriggerExit(Collider collision)
    {
        GameObject localObject = collision.gameObject;
        if (localObject.GetComponent<CharacterController>() && localObject.transform.GetChild(0).GetComponent<Camera>().enabled == true)
        {
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
}
