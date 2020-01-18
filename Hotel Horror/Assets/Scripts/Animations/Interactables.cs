using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactables : MonoBehaviour
{
    //Distance between player and what they're looking at
    public float hitDistance;

    //Crosshair for testing
    public Image crosshair;

    void Update()
    {
        //Create RaycastHit object
        RaycastHit hit;

        //Create raycast from player camera to 100 meters forward
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            hitDistance = hit.distance;

            //Print object name and distance to console every frame
            Debug.Log(hit.collider.name + ", " + hit.distance);

            //Call InteractWith on the object that the player is looking at
            //If the player presses E on an object tagged as interactable that's within 4.0 meters
            if(Input.GetKeyDown(KeyCode.E) && hitDistance < 3.0f)
            {
                if (hit.collider.tag == "Interactable")
                    interactWith(hit);
                else
                    Debug.Log("This is not an interactable object.");
            }

            //Change crosshair color when looking at an Interactable object
            if (hit.collider.tag == "Interactable" && hitDistance < 3.0f)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;
            }
        }
    }

    public void interactWith(RaycastHit hit)
    {
        //Kitchen Cabinets
        if (hit.collider.name == "cabinet1door1")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
               if(!hit.collider.GetComponent<InteractableObject>().isOpen)
               {
                    hit.collider.GetComponent<Animation>().Play("cabinet1door1open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
               }
               else
               {
                    hit.collider.GetComponent<Animation>().Play("cabinet1door1close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "cabinet1door2")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("cabinet1door2open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("cabinet1door2close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "cabinet1door3")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("cabinet1door3open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("cabinet1door3close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "cabinet1door4")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("cabinet1door4open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("cabinet1door4close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }

        //Bathroom Cabinets
        else if (hit.collider.name == "cabinet2door1")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("cabinet2door1open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("cabinet2door1close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "cabinet2door2")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("cabinet2door2open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("cabinet2door2close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "cabinet2door3")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("cabinet2door3open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("cabinet2door3close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }

        //Light Switches
        else if (hit.collider.name == "LightSwitch")
        {
            //hit.collider.GetComponent<LightswitchController>().FlipSwitch();          Sean Did THIS. Your Code is BROKEN
            Debug.Log("Lights on: " + hit.collider.GetComponent<LightswitchController>().lightsOn);
        }

        //Refrigerators
        else if (hit.collider.name == "fridgedoor1")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("fridgedoor1open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("fridgedoor1close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "fridgedoor2")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("fridgedoor2open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("fridgedoor2close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "fridgedrawer1")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("fridgedrawer1open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("fridgedrawer1close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "fridgedrawer2")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("fridgedrawer2open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("fridgedrawer2close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "fridgedrawer3")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("fridgedrawer3open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("fridgedrawer3close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }

        //Beds
        else if (hit.collider.name == "beddrawer1")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("beddrawer1open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("beddrawer1close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "beddrawer2")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("beddrawer2open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("beddrawer2close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "beddrawer3")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("beddrawer3open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("beddrawer3close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "beddrawer4")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("beddrawer4open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("beddrawer4close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }

        //Old Dresser
        else if (hit.collider.name == "OldDrawer1")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("drawer1open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("drawer1close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "OldDrawer2")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("drawer2open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("drawer2close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "OldDrawer3")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("drawer3open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("drawer3close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "OldDrawer4")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("drawer4open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("drawer4close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "OldDrawer5")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("drawer5open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("drawer5close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "OldDrawer6")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("drawer6open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("drawer6close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "OldDrawer7")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("drawer7open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("drawer7close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "OldDrawer8")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("drawer8open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("drawer8close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "OldDrawer9")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("drawer9open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("drawer9close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }

        //Bathroom Drawers
        else if (hit.collider.name == "BathroomDrawer1")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("drawer1open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("drawer1close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "BathroomDrawer2")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("drawer2open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("drawer2close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "BathroomDrawer3")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("drawer3open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("drawer3close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
        else if (hit.collider.name == "BathroomDrawer4")
        {
            if (!hit.collider.GetComponent<Animation>().isPlaying)
            {
                if (!hit.collider.GetComponent<InteractableObject>().isOpen)
                {
                    hit.collider.GetComponent<Animation>().Play("drawer4open");
                    hit.collider.GetComponent<InteractableObject>().isOpen = true;
                    Debug.Log("Open");
                }
                else
                {
                    hit.collider.GetComponent<Animation>().Play("drawer4close");
                    hit.collider.GetComponent<InteractableObject>().isOpen = false;
                    Debug.Log("Close");
                }
            }
            else
            {
                Debug.Log("Animation is already playing!");
            }
        }
    }

}
