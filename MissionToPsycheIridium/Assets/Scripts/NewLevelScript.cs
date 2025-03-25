using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelScript : MonoBehaviour
{
    public AudioClip buttonSound;
    public bool isNewLevel;
    [SerializeField] GameObject newLevel;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = buttonSound;
        GetComponent<AudioSource>().playOnAwake = false;
    }

    void playButtonSound()
    {
        GetComponent<AudioSource>().Play();
    }

    //start main level

    // Update is called once per frame
    void Update()
    {
        
    }
}
