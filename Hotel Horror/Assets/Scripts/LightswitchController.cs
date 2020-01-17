using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightswitchController : MonoBehaviour
{
    public Light[] lightSources;

    public bool lightsOn;

    public void flipSwitch()
    {
        if(lightsOn)
        {
            for(int i = 0; i < lightSources.Length; i++)
            {
                lightSources[i].enabled = false;
                lightsOn = false;
            }
        }
        else
        {
            for (int i = 0; i < lightSources.Length; i++)
            {
                lightSources[i].enabled = true;
                lightsOn = true;
            }
        }
    }
}
