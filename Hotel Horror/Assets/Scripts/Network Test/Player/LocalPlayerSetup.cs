using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LocalPlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] disableComponentArray;

    void Start()
    {
        diableComponents();
    }

    private void diableComponents()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < disableComponentArray.Length; i++)
            {
                disableComponentArray[i].enabled = false;
            }
        }
    }
}
