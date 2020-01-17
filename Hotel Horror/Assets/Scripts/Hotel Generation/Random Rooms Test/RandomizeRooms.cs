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
            count += 1;
        }       
        placeRooms();
    }

    private void placeCornerRoom(float x, float y, float z, float r)
    {
        Debug.Log("Place corner room");
        int rand = Random.Range(1, 2);
        GameObject localRoom = null;
        if (rand == 1)
        {
            localRoom = room1;
        }
        if (rand == 2)
        {
            localRoom = room2;
        }
        GameObject newRoom = Instantiate(localRoom, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        newRoom.transform.Rotate(Vector3.up, r, Space.Self);
        newRoom.transform.parent = gameObject.transform;
        newRoom.transform.localPosition = new Vector3(x, y, z);
    }

    private void placeRooms()
    {
        float x = 0;
        float y = 0.0f;
        float z = 0f;
        float r = 0f;
        //Loops through the first half of rooms and instatiates random guest rooms
        for (int i=0; i<rooms.Length/2; i++)
        {
            if (rooms[i] == 1 || rooms[i] == roomAmount/2)
            {
                placeCornerRoom(x,y,z,r);
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
                GameObject newRoom = Instantiate(localRoom, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                newRoom.transform.parent = gameObject.transform;
                newRoom.transform.localPosition = new Vector3(x, y, z);
            }
            z += 20;
        }

        //Resets x, y, and z for second row
        x = 0f;
        y = 0.0f;
        z = -80f;
        r = 180f;
        //Loops through the second half of rooms and instatiates random guest rooms
        for (int i = rooms.Length / 2; i < rooms.Length; i++)
        {
            if (rooms[i] == (rooms.Length / 2) + 1 || rooms[i] == roomAmount)
            {
                placeCornerRoom(x, y, z, r);
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
                GameObject newRoom = Instantiate(localRoom, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                newRoom.transform.Rotate(Vector3.up, 180f, Space.Self);
                newRoom.transform.parent = gameObject.transform;
                newRoom.transform.localPosition = new Vector3(x, y, z);
            }
            z += 20;
        }
    }
}
