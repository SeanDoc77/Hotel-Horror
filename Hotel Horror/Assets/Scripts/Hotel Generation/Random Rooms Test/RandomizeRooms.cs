using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeRooms : MonoBehaviour
{
    public GameObject powerRoom;
    public GameObject utilityRoom;
    public GameObject room1;
    public GameObject room2;
    public GameObject room3;

    public int roomAmount;

    public float roomWidth;
    public float roomLength;

    int[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        //Creates array from 1 to roomAmount
        rooms = new int[roomAmount];
        int count = 1;
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i] = count;
        }

    }

    private void placeCornerRoom(int corner)
    {
        Debug.Log("Place corner room");
    }

    private void placeRoom()
    {
        //Loops through the first half of rooms and instatiates random guest rooms
        for (int i=0; i<rooms.Length/2; i++)
        {
            if (rooms[i] == 1 || rooms[i] == roomAmount/2)
            {
                placeCornerRoom(rooms[i]);
            }
            else
            {
                int rand = Random.Range(1, 3);
                GameObject localRoom = null;
                if (rand == 1)
                {
                    localRoom = room1;
                }
                if (rand == 2)
                {
                    localRoom = room2;
                }
                if (rand == 3)
                {
                    localRoom = room3;
                }
                //Instantiate(localRoom, new Vector3(0f, spawnHeight + floorHeight * floorCount, 0f), Quaternion.identity);
            }
        }
    }
}
