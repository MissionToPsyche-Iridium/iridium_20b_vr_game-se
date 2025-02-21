using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class NickleScript : MonoBehaviour
{
    [SerializeField] private Vector3[] nickelLocations;
    [SerializeField] private GameObject[] nickelObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void placeNicklePickups()
    {
        
        //TODO: fill location array
        //TODO: randomize location array
        int count = 0;
        foreach (GameObject nickelObj in nickelObjects) {
            nickelObj.transform.position = nickelLocations[count];
            count++;
        }
    }

    public String locationsToString()
    {
        String locStr = "";
        foreach (Vector3 location in nickelLocations)
        {
            locStr = location.ToString();
        }
        return locStr;
    }

    private void randomizeList()
    {
        //TODO: randomize List of locations
        System.Random rand = new System.Random();
        List<int> numbers = new();

        for (int i = 0; i < nickelLocations.Length; i++) 
        {
            numbers.Add(i);
        }

        foreach (GameObject nickel in nickelObjects)
        {
            int index = rand.Next(nickelLocations.Length);
            while (!numbers.Contains(index))
            {
                index = rand.Next(nickelLocations.Length);
            }

            nickel.transform.position = nickelLocations[index];
        }

    }

    //private void populateLocations()
    //{
    //    nickelLocations = {}
    //}
}
