﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AssignPrefabToRoom : MonoBehaviour
{
    private int generatePreFabToRoom(int seed, int id, int numPreFabs)
    {
        // create a new number using seed and id
        int newSeedInt = (int)Mathf.Ceil(seed / id);
        string newSeedStr = newSeedInt.ToString();
        //Debug.Log(newSeedStr);
        //Debug.Log(newSeedStr.Length);
        // number of digits of the seed we want(based on # prefabs we have)
        string maxStr = "" + numPreFabs;
        int X = maxStr.Length;

        // get an X digit number from our seed
        newSeedStr = newSeedStr.Substring(newSeedStr.Length - X - 1, X + 1);

        float newSeed = float.Parse(newSeedStr);
        // Debug.Log("newSeed: " + newSeed);

        // this needs to be mapped to a number from 1 to numPrefabs,
        // which will be our prefabID
        int prefabID = (int)Mathf.Floor(numPreFabs * newSeed / (Mathf.Pow(10, X+1)));

        //Debug.Log("prefabID: " + prefabID);

        // prefabID currently is a value from 0 to numPreFabs-1
        // to make it go from 1 to numPreFabs, change 
        // line 18: newSeedStr = newSeedStr.Substring(newSeedStr.Length - X, X + 1);
        // line 23: int prefabID = (int)Mathf.Floor(10 * newSeed / numPreFabs);
        return prefabID+1;
    }
    private void Start()
    {
        int[] arr = new int[100];
        for (int i = 0; i < 100; i++)
        {
            arr[i] = generatePreFabToRoom(UnityEngine.Random.Range(10000, 2147483647), UnityEngine.Random.Range(1, 101), 2);
        }
        Array.Sort(arr);
        for (int i = 0; i < 100; i++)
        {
            Debug.Log(arr[i]);
        }
    }
}