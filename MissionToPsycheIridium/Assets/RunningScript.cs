using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class RunningScript : MonoBehaviour
{
    [SerializeField] private ActionBasedContinuousMoveProvider moveObject;
    [SerializeField] private InputActionReference runButton;
    public CharacterController charController;
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float runVal = runButton.action.ReadValue<float>();

        if(runVal > 0 && !isRunning) //if button is pressed?  while not running
        {
            isRunning = true;
            moveObject.moveSpeed *= 1.3f;
        }

        //if running, keep running
        if (isRunning)
        {
            //print out value of InputAction (assuming if > 0, button is pressed)
            print("running:" + runButton.action.ReadValue<float>()); //debug


            
        }

        //if not running, check if running
        else if (!isRunning) 
        {
            isRunning = true;
            moveObject.moveSpeed *= 1.3f; 
        }
        
    }

    private void Run()
    {

    }
}
