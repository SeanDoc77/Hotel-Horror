using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelConstructor : MonoBehaviour
{
    //Creates new seed object
    HotelSeed hotelSeed = new HotelSeed();
    int seed;
    void Start()
    {
        //Generates new seed
        hotelSeed.generateSeed();
        seed = HotelSeed.seed;
    }
}
