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
        //Declares the Y value to instatiate the main floor
        float spawnHeight = floorHeight / 2;

        //Instantiates the main and second floor prefabs
        Instantiate(mainFloor, new Vector3(0f, spawnHeight, 0f), Quaternion.identity);
        Instantiate(secondFloor, new Vector3(0f, spawnHeight + floorHeight, 0f), Quaternion.identity);

        //Instantiates the remaing guest floors
        addGuestFloors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Function that generates create a random amout of floors above the second floor
    private void addGuestFloors()
    {
        //Declares the Y value offset instatiate new floors
        float spawnHeight = floorHeight / 2;

        //Creates a random integer between (minFloorCount - 2) and (maxFloorCount - 2)
        int guestFloors = Random.Range(minFloorCount, maxFloorCount)-2;

        //Create a floor counter starting with 2 which represents the first 2 floors
        int floorCount = 2;
        for (int i=0; i<guestFloors; i++)
        {
            Instantiate(guestFloor, new Vector3(0f, spawnHeight + floorHeight*floorCount, 0f), Quaternion.identity);
            floorCount++;
        }

    }
}
