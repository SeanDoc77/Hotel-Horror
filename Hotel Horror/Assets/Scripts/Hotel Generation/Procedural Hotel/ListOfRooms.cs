using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfRooms : MonoBehaviour
{
    public GameObject room1;
    public GameObject room2;

    public static List<GameObject> guestRoomList = new List<GameObject>();

    void Start()
    {
        guestRoomList = guestRooms();
    }
    public  List<GameObject> guestRooms()
    {
        List<GameObject> guestRoomList = new List<GameObject>();
        guestRoomList.Add(room1);
        guestRoomList.Add(room2);
        guestRoomList.Add(room2);
        return guestRoomList;
    }
}
