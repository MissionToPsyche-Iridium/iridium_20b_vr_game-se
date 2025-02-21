using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Light globalLight;

    // Start is called before the first frame update
    void Start()
    {
        globalLight.color = new Color(0.3f, 0.7f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
