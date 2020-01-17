using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AssignPrefabToRoom : MonoBehaviour
{
    private int generatePreFabToRoom(int seed, int id, int numPreFabs)
    {
        // create a new number using seed and id
        string newSeedStr = "" + Mathf.Ceil(seed / id);

        // number of digits of the seed we want(based on # prefabs we have)
        string maxStr = "" + numPreFabs;
        int X = maxStr.Length;

        // get an X digit number from our seed
        newSeedStr = newSeedStr.Substring(newSeedStr.Length - X, X);

        float newSeed = float.Parse(newSeedStr);
        // this needs to be mapped to a number from 1 to numPrefabs,
        // which will be our prefabID
        int prefabID = (int)Mathf.Ceil(10 * newSeed / numPreFabs);
        
        return prefabID;
    }
    private void Start()
    {
        int[] arr = new int[100];
        for (int i = 0; i < 100; i++)
        {
            arr[i] = generatePreFabToRoom(UnityEngine.Random.Range(10000, 1000001), UnityEngine.Random.Range(1, 101), 32);
        }
        Array.Sort(arr);
        for (int i = 0; i < 100; i++)
        {
            Debug.Log(arr[i]);
        }
    }
}
