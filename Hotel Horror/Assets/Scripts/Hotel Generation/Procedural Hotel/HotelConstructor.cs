using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HotelConstructor : MonoBehaviour
{
    public int minFloors;
    public int maxFloors;

    //Creates new seed object
    HotelSeed hotelSeed = new HotelSeed();
    int seed;
    void Start()
    {
        //Generates new seed
        hotelSeed.generateSeed();
        seed = HotelSeed.seed;
        determineFloorsToAdd(2129857807, minFloors, maxFloors);
        Debug.Log(seed);
    }

    private int determineFloorsToAdd(int seed, int minFloors, int maxFloors)
    {
        int floorAmount;
        int digits = 2; //Number of digits to pick from middle of seed

        float max = (float)maxFloors-(float)(minFloors); //Number of floors that can potentially be added
        string seedString = seed.ToString(); //Converts the seed int to a string
        int stringLength = seedString.Length; //Gets the amount of digits in the seed string

        //Calculate a percentage using the middle two digit of the seed
        string subString = seedString.Substring((int)(stringLength/2) - (int)(digits/2),  digits); //Gets the middle two digits of the seed
        float output = Int32.Parse(subString);//Converts the middle two digits to a float
        float percentage = (output / 100); //Divides the 2 digit output by 100 to generate a percentage
        float amount = percentage * max; //Multiplies the max potential floors by the percentage
        floorAmount = Mathf.RoundToInt(amount); // *maxFloors;


        Debug.Log(floorAmount);
        return floorAmount;
    }
}
