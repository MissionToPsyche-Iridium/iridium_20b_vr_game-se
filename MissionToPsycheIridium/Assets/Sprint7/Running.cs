using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Running : MonoBehaviour
{

    public ContinuousMoveProviderBase continuousMoveProviderBase;
    public InputActionReference runButton = null;
    private bool isRunning = false;
    public float walkingSpeed = 5.28f;
    public float runningSpeed = 10.0f;
    private float timer = 0.0f;
    private float timeOut = 10.0f;
    [SerializeField]
    float runningTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        isRunning = true; 
    }

    // Update is called once per frame
    void Update()
    {
        float runVal = runButton.action.ReadValue<float>();
        if (runVal > 0 && isRunning == true)
        {
            timer += Time.deltaTime;
            Debug.Log("button pressed");
            //isRunning = false;
            runButtonAction();
            if (timer > runningTime)
            {

            }
        }
        if (runVal == 0)
        {
            isRunning = true;
        }
        
    }

    void runButtonAction()
    {
        if (isRunning == false)
        {
            return;
        }
        continuousMoveProviderBase.moveSpeed = runningSpeed;
        Debug.Log(continuousMoveProviderBase.moveSpeed);
    }
}
