using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class OnlineSeed
{
    //Global seed variable
    [SyncVar]
    public int seed;

    public void generateSeed()
    {
        //Create a random int between 1,000,000,000 and 2,147,483,647
        int rand = Random.Range(10000, 2147483647);

        //Sets global seed varible to the random seed
        HotelSeed.seed = rand;
    }
}
