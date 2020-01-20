using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HotelConstructor : MonoBehaviour
{
    public GameObject floor;
    public int minFloors;
    public int maxFloors;

    HotelSeed hotelSeed = new HotelSeed(); //Creates new seed object

    int seed;
    int floorAmount; //Number of floors to add

    void Start()
    {
        hotelSeed.generateSeed(); //Generates new seed
        seed = HotelSeed.seed;

        constructHotel();
        disableRooms();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Determines the amount of floors to add on top of the minimum floor amount
    private int determineFloorsToAdd(int seed, int minFloors, int maxFloors)
    {
        int floorAmount;
        int digits = 3; //Number of digits to pick from middle of seed

        float max = (float)maxFloors - (float)(minFloors); //Number of floors that can potentially be added
        string seedString = seed.ToString(); //Converts the seed int to a string
        int stringLength = seedString.Length; //Gets the amount of digits in the seed string

        //Calculate a percentage using the middle two digit of the seed
        string subString = seedString.Substring((int)(stringLength / 2) - (int)(digits / 2), digits); //Gets the middle two digits of the seed
        float output = Int32.Parse(subString);//Converts the middle two digits to a float
        float percentage = (float)(output / Math.Pow(10, digits)); //Divides the 2 digit output by 100 to generate a percentage
        float amount = percentage * max; //Multiplies the max potential floors by the percentage
        floorAmount = Mathf.RoundToInt(amount); // *maxFloors;

        Debug.Log(floorAmount);
        return floorAmount;
    }

    //Method to constuct the hotel
    private void constructHotel()
    {
        floorAmount = determineFloorsToAdd(seed, minFloors, maxFloors) + minFloors;
        createFloors(floorAmount);
        addRooms();
    }
    private void createFloors(int floorAmount)
    {
        GameObject emptyObject = new GameObject(); //Creates empty game object

        int y = 0; //Starting height of floor;
        for (int i = 1; i <= floorAmount; i++)
        {
            GameObject newFloor = Instantiate(floor, new Vector3(0, y, 0), Quaternion.identity); //Adds new floor
            newFloor.tag = "floor";
            newFloor.name = "Floor: " + i.ToString();

            //Instantiate a new room at these coordinates using the Floor's y coordinate
            int xR = -15;
            int zR = -40;

            int count = 1;
            for (int j = 1; j <= 10; j++)
            {
                GameObject newRoom = Instantiate(emptyObject, new Vector3(xR, y, zR), Quaternion.identity); //Adds empty game objects to floor
                newRoom.transform.parent = newFloor.transform;
                newRoom.tag = "room";

                //This if else statement creates the room naming convention
                if (i < 10)
                {
                    if (j < 10)
                    {
                        newRoom.name = "0" + i.ToString() + "0" + j.ToString();
                    }
                    else
                    {
                        newRoom.name = "0" + i.ToString() + j.ToString();
                    }
                }
                else
                {
                    if (j < 10)
                    {
                        newRoom.name = i.ToString() + "0" + j.ToString();
                    }
                    else
                    {
                        newRoom.name = i.ToString() + j.ToString();
                    }
                }

                zR += 20; //Adds 20 to the rooms Z direction to instantiate next object

                count += 1;
                if (count > 5) //If statement changes Z coordinate after half of the rooms floors are instantiated
                {
                    xR = 15;
                    zR = -40;
                    count = 0;
                }
            }

            y += 5; //Increase floor height by 5
        }
    }

    private void addRooms()
    {
        //Obtain the list of rooms
        List<GameObject> listOfGuestRooms = ListOfRooms.guestRoomList;

        GameObject[] rooms = GameObject.FindGameObjectsWithTag("room");

        foreach (GameObject room in rooms)
        {
            string roomName = room.name; //Gets the room number from the room name

            int prefabID = generatePreFabToRoom(seed, int.Parse(roomName), listOfGuestRooms.Count); //Generates a prefab ID based on the seed and room number
            GameObject localRoom = listOfGuestRooms[prefabID - 1]; //Creates a temporary gameobject from a list of prefabs
            GameObject newRoom = Instantiate(localRoom, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity); //Instantiates the room
            newRoom.transform.parent = room.transform;
            newRoom.transform.localPosition = new Vector3(0, 0, 0);

            //Debug.Log(roomName);
            string roomNumber = roomName.Substring(roomName.Length - 2, 2); //Get last tow digits of room number
            int num = int.Parse(roomNumber); //Converts roomNumber to int

            if (num > 5) //If the last two digits of the room numnber are greater than five, then rotate the new room 180 degrees around the y axis
            {
                newRoom.transform.Rotate(Vector3.up, 180, Space.Self);
            }
        }
    }

    private int generatePreFabToRoom(int seed, int id, int numPreFabs)
    {
        // create a new number using seed and id
        int newSeedInt = (int)Mathf.Ceil(seed / id);
        string newSeedStr = newSeedInt.ToString();

        // number of digits of the seed we want(based on # prefabs we have)
        string maxStr = "" + numPreFabs;
        int X = maxStr.Length;

        // get an X digit number from our seed
        newSeedStr = newSeedStr.Substring(newSeedStr.Length - X - 1, X + 1);

        float newSeed = float.Parse(newSeedStr);
        // Debug.Log("newSeed: " + newSeed);

        // this needs to be mapped to a number from 1 to numPrefabs,
        // which will be our prefabID
        int prefabID = (int)Mathf.Floor(numPreFabs * newSeed / (Mathf.Pow(10, X + 1)));

        //Debug.Log("prefabID: " + prefabID);

        // prefabID currently is a value from 0 to numPreFabs-1
        // to make it go from 1 to numPreFabs, change 
        // line 18: newSeedStr = newSeedStr.Substring(newSeedStr.Length - X, X + 1);
        // line 23: int prefabID = (int)Mathf.Floor(10 * newSeed / numPreFabs);
        return prefabID + 1;
    }

    private void disableRooms()
    {
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("room");

        foreach (GameObject room in rooms)
        {
            room.active = false;
        }
    }
}
