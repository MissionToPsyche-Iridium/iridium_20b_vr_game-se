using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        ScoringSystem.theScore += 1;
        Destroy(gameObject);
    }
}
