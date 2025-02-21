using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIVisibility : MonoBehaviour
{
    public Transform cameraTransform;

    void LateUpdate()
    {
        transform.position = cameraTransform.position + cameraTransform.forward * 2f; 
        transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
    }
}
