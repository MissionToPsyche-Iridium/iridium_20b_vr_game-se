using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RunAction : MonoBehaviour
{

    public InputActionReference runButton = null;
    public CharacterController charController;
    public float jumpHeight;
    public ActionBasedContinuousMoveProvider cmp;
    private float gravityValue = 0;

    private Vector3 playerVelocity;

    public bool runButtonReleased;

    private bool isTouchingGround;
    // Start is called before the first frame update
    void Start()
    {
        runButtonReleased = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (charController.isGrounded)
        {
        
            isTouchingGround = true;
        }

        float jumpVal = runButton.action.ReadValue<float>();
        if (jumpVal > 0 && runButtonReleased == true)
        {
            runButtonReleased = false;
            Run();
        }
        
            runButtonReleased = true;
        
    }

    public void Run()
    {
        if (isTouchingGround == false)
        {
            return;
        }
        cmp.moveSpeed = 5;
    }

}
