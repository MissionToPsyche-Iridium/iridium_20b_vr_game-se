using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void randomizeList()
    {
        //TODO: randomize List of locations
    }
}
