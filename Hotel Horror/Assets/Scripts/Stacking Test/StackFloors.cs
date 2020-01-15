using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackFloors : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainFloor;
    public GameObject secondFloor;
    public GameObject guestFloor;
    public int minFloorCount;
    public int maxFloorCount;
    public float floorHeight;

    void Start()
    {
        Instantiate(mainFloor);
        Instantiate(secondFloor, new Vector3(0f, floorHeight, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Function that generates create a random amout of floors above the second floor
    private void addGuestFloors()
    {

    }
}
