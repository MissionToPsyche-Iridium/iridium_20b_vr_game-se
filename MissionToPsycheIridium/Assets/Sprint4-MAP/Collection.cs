using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// How it works:
// When you create a collectible object, make sure to check the "Is Trigger" on the collider, and give it the "Metal" tag

public class Collection : MonoBehaviour
{
    private int Score = 0;
    public Text UIscore;
    public AudioClip collect;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Metal")
        {
            Score++;
            UIscore.text = Score.ToString();
            AudioSource noise = GetComponent<AudioSource>();
            noise.Play();
            Debug.Log(Score);
            Destroy(other.gameObject);
        }
    }
}
