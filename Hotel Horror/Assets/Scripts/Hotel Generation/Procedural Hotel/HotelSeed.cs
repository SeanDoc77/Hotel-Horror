using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelSeed
{
    //Global seed variable
    public static int seed;

    public void generateSeed()
    {
        //Create a random int between 0 and 9999999999
        int rand = Random.Range(0, 31622);

        //Sets global seed varible to the random seed
        HotelSeed.seed = rand;
    }
}
