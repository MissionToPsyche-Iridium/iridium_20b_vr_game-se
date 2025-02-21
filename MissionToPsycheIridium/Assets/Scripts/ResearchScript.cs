using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchScript : MonoBehaviour
{
   
    [SerializeField] GameObject worldSpace;
    public AudioSource sound;
    
    
    private int collisions;
    

    void Start()
    {
        
        collisions = 0;

    }



    private void OnTriggerEnter(Collider other)
    {
        
        if (collisions < 1)
        {

            if (other.gameObject.name == "leftHand" || other.gameObject.name == "rightHand" || other.gameObject.tag == "Player" || other.gameObject.name == "player")
            {
                collisions++;
                Debug.Log("collision detected, sound played");
                sound.Play();
                
                
                worldSpace.SetActive(true);
                
                
                


            }
        }
    }

}
