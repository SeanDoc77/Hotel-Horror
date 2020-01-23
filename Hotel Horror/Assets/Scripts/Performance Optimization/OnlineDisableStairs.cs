using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class OnlineDisableStairs : NetworkBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        GameObject localObject = collision.gameObject;
        if (localObject.GetComponent<CharacterController>() && localObject.transform.GetChild(0).GetComponent<Camera>().enabled == true)
        {
            Debug.Log("isLocalPlayer");
            foreach (Transform room in gameObject.transform.parent.transform)
            {
                if (room.transform.tag == "stairway")
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
                if (room.transform.tag == "stairway")
                {
                    room.gameObject.active = false;
                }
            }
        }
    }
}
