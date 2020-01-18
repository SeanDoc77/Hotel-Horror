using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HotelConstructor : MonoBehaviour
{
    public GameObject floor;
    public GameObject room1;
    public int minFloors;
    public int maxFloors;

    HotelSeed hotelSeed = new HotelSeed(); //Creates new seed object

    int seed;
    int floorAmount; //Number of floors to add
    
    void Start()
    {
        hotelSeed.generateSeed(); //Generates new seed
        seed = HotelSeed.seed;

        floorAmount = determineFloorsToAdd(seed, minFloors, maxFloors) + minFloors;
        createRoomGrid(floorAmount, minFloors, maxFloors);
        addRooms();
        Debug.Log(seed);
    }

    //Method that determines how many foors to add
    private int determineFloorsToAdd(int seed, int minFloors, int maxFloors)
    {
        int floorAmount;
        int digits = 3; //Number of digits to pick from middle of seed

        float max = (float)maxFloors-(float)(minFloors); //Number of floors that can potentially be added
        string seedString = seed.ToString(); //Converts the seed int to a string
        int stringLength = seedString.Length; //Gets the amount of digits in the seed string

        //Calculate a percentage using the middle two digit of the seed
        string subString = seedString.Substring((int)(stringLength/2) - (int)(digits/2),  digits); //Gets the middle two digits of the seed
        float output = Int32.Parse(subString);//Converts the middle two digits to a float
        float percentage = (float)(output / Math.Pow(10, digits)); //Divides the 2 digit output by 100 to generate a percentage
        float amount = percentage * max; //Multiplies the max potential floors by the percentage
        floorAmount = Mathf.RoundToInt(amount); // *maxFloors;

        Debug.Log(floorAmount);
        return floorAmount;
    }

    //Method that creates a grid of empty game objects that will be used to add rooms
    private void createRoomGrid(int floorAmount, int minFLoors, int maxFloors)
    {
        GameObject emptyObject = new GameObject(); //Creates empty game object
        int towerRoomAmount = 10 * floorAmount; //number of floors

        //starting position of empty game objects
        int x = -15;
        int y = 0;
        int z = -40;

        int counter = 0; //counter resets every 5 loops
        int floorCount = 1;
        for(int i = 1; i <= towerRoomAmount; i++)
        {
            if (i <= towerRoomAmount / 2)
            {
                //Instantiate an empty gameobject with tag "Room" and name "(number)"
                GameObject newRoom = Instantiate(emptyObject, new Vector3(x, y, z), Quaternion.identity);
                newRoom.tag = "Left Room";
                newRoom.name = i.ToString();

                z += 20; //Add 20 to the z coordinate for next gameobject

                //Reset z and add 5 to y when a new floor begins
                counter += 1;
                if (counter > 4)
                {
                    GameObject newFloor = Instantiate(floor, new Vector3(0, y, 0), Quaternion.identity);
                    newFloor.name = "Floor: " + floorCount.ToString();
                    floorCount++;
                    z = -40;
                    y += 5;
                    counter = 0;
                }
                if(i >= towerRoomAmount / 2)
                {
                    y = 0;
                }
            }
            else
            {
                //Instantiate an empty gameobject with tag "Room" and name "(number)"
                GameObject newRoom = Instantiate(emptyObject, new Vector3(-x, y, z), Quaternion.Euler(0f, 180f, 0f));
                newRoom.tag = "Left Room";
                newRoom.name = i.ToString();

                z += 20; //Add 20 to the z coordinate for next gameobject

                //Reset z and add 5 to y when a new floor begins
                counter += 1;
                if (counter > 4)
                {
                    z = -40;
                    y += 5;
                    counter = 0;
                }
            }
        }
    }

    private void addRooms()
    {
        int towerRoomAmount = 10 * floorAmount;
        for (int i = 1; i <= towerRoomAmount; i++)
        {
            int roomdID = generatePreFabToRoom(seed, i, 1);
            Debug.Log("roomID: " + roomdID);
        }
    }

    private int generatePreFabToRoom(int seed, int id, int numPreFabs)
    {
        // create a new number using seed and id
        string newSeedStr = "" + Mathf.Ceil(seed / id);

        // number of digits of the seed we want(based on # prefabs we have)
        string maxStr = "" + numPreFabs;
        int X = maxStr.Length;

        // get an X digit number from our seed
        newSeedStr = newSeedStr.Substring(newSeedStr.Length - X - 1, X + 1);

        float newSeed = float.Parse(newSeedStr);
        // this needs to be mapped to a number from 1 to numPrefabs,
        // which will be our prefabID
        int prefabID = (int)Mathf.Floor(newSeed / numPreFabs);

        // prefabID currently is a value from 0 to numPreFabs-1
        // to make it go from 1 to numPreFabs, change 
        // line 18: newSeedStr = newSeedStr.Substring(newSeedStr.Length - X, X + 1);
        // line 23: int prefabID = (int)Mathf.Floor(10 * newSeed / numPreFabs);
        return prefabID;
    }
}
