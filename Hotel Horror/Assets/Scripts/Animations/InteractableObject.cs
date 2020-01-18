using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool isOpen = false;
    public bool isLocked = false;

    public bool animatorIsPlaying()
    {
        return this.transform.parent.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length > this.transform.parent.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
