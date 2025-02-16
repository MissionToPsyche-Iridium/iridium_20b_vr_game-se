using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Running : MonoBehaviour
{

    public ContinuousMoveProviderBase continuousMoveProviderBase;
    public InputActionReference runButton = null;
    private bool isRunning = false;
    private bool runningButtonPressed = false;
    public float walkingSpeed = 5.28f;
    public float runningSpeed = 10.0f;
    private float timer = 0.0f;
    private float timeOut = 10.0f;
    [SerializeField]
    float runningTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        isRunning = false; 
    }

    // Update is called once per frame
    void Update()
    {
        float runVal = runButton.action.ReadValue<float>();
        
        if (runVal > 0 && isRunning == false)
        {
            runVal = 1;
            Debug.Log("button pressed");
            //isRunning = false;
            //timer += Time.deltaTime;
            
           
            StartCoroutine(runButtonAction());
            runningButtonPressed = true;
             
            /*if (timer >= runningTime && timer < timeOut)
            {
                Debug.Log("timer 2nd if : " + timer);
                isRunning = false;
                continuousMoveProviderBase.moveSpeed = walkingSpeed;
            } 
            if (timer >= timeOut)
            {
                runningButtonPressed = false;
                runVal = 0;
                Debug.Log("timer 3nd if : " + timer);
            }*/
            


        }
        if (runningButtonPressed == false && isRunning == false)
        {
            continuousMoveProviderBase.moveSpeed = walkingSpeed;
            //isRunning = true;
        }
        
    }

    IEnumerator runButtonAction()
    {

        isRunning = true;

        float runTimer = 0f;

        while (runTimer < timeOut)
        {
            continuousMoveProviderBase.moveSpeed = runningSpeed;
            runTimer += Time.deltaTime;
            if (runTimer >= runningTime)
            {
                continuousMoveProviderBase.moveSpeed = walkingSpeed;
            }
            yield return null;
        }

        isRunning = false;
        runningButtonPressed = false;


            /*if (runningButtonPressed == true)
            {
                return;
            }
            continuousMoveProviderBase.moveSpeed = runningSpeed;
            Debug.Log(continuousMoveProviderBase.moveSpeed);*/
        }

    void runButtonDisabled()
    {
        
    }

    void runButtonTimeOut()
    {
        continuousMoveProviderBase.moveSpeed = walkingSpeed;
        isRunning = true;
    }
}
