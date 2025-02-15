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
    [SerializeField] private float SpeedMult = 1.3f;
    public CharacterController charController;
    private bool isRunning = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //I'm assuming here that runVal > 0 indicates a run button is on
        float runVal = runButton.action.ReadValue<float>();

        if (runVal > 0 && !isRunning) //if button is pressed?  while not running
        {
            isRunning = true;
            moveObject.moveSpeed *= SpeedMult;
            print("run button pressed");
        }

        //if running and button is released
        else if (!(runVal > 0) && isRunning)
        {
            isRunning = false;
            moveObject.moveSpeed /= SpeedMult;
            print("run button released");
        }

    }

    private void Run()
    {

    }
}
