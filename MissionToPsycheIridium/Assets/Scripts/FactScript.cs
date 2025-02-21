using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactScript : MonoBehaviour
{
    public Transform mainCam;
    public Transform worldSpaceCanvas;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.transform;
        worldSpaceCanvas = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position); //look at the camera
    }
}
