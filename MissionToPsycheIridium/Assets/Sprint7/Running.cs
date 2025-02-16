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
    public AudioSource runningSound;
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
    
            
           
            StartCoroutine(runButtonAction());
            runningButtonPressed = true;
            

        }
        if (runningButtonPressed == false && isRunning == false)
        {
            continuousMoveProviderBase.moveSpeed = walkingSpeed;
    
        }
        
    }

    IEnumerator runButtonAction()
    {

        isRunning = true;

        float runTimer = 0f;

        runningSound.Play();
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
