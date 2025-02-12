using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class RunningScript : MonoBehaviour
{
    [SerializeField] private ActionBasedContinuousMoveProvider moveObject;
    [SerializeField] private InputActionProperty runButton;

    private void OnEnable()
    {
        runButton.EnableDirectAction();
    }

    private void OnDisable()
    {
        runButton.EnableDirectAction();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (runButton.action.performed)
        {
            moveObject.moveSpeed *= 1.3f;
        }
    }
}
