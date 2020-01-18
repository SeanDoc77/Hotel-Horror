using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HotelConstructor : MonoBehaviour
{
    public int minFloors;
    public int maxFloors;

    HotelSeed hotelSeed = new HotelSeed(); //Creates new seed object

    int seed;
    int addFloors; //Number of floors to add
    
    void Start()
    {
        hotelSeed.generateSeed(); //Generates new seed
        seed = HotelSeed.seed;

        addFloors = determineFloorsToAdd(seed, minFloors, maxFloors);
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
    private void createRoomGrid(int minFLoors, int addFloors)
    {

    }
}
