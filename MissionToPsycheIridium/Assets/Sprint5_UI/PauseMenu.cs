using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; 
    public InputActionProperty pressPause;
    public TMP_Text timerText;                
    public Button resumeButton;
    public Transform cameraTransform;      // Reference to the camera
    public XRRayInteractor leftRay;        // Reference to left ray interactors
    public XRRayInteractor rightRay;       // Reference to right ray interactors
    public XRDirectInteractor leftDirect; // Reference to left direct interactor
    public XRDirectInteractor rightDirect; // Reference to right direct interactor

    private bool isPaused = false;         // Tracks when game is paused
    private float gameTime = 0f;           // The game timer
    private float timeScaleBeforePause;    // Stores timer before pausing the game
   

    // Start is called before the first frame update
    void Start()
    {
        //Hide pause menu when game starts
        pauseMenu.SetActive(false);

        //Set up listener for resume button
        resumeButton.onClick.AddListener(OnResumeButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the game timer if the game is not paused
        if (!isPaused)
        {
            gameTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    private void OnEnable()
    {
        pressPause.action.performed += DisplayPause;
    }

    private void OnDisable()
    {
        pressPause.action.performed -= DisplayPause;
    }

    private void DisplayPause(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            ResumeGame(); // Resume the game if it's currently paused
        }
        else
        {
            PauseGame(); // Pause the game if it's currently running
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        PositionPauseMenu(); // Position pause menu in front of the camera
        pauseMenu.SetActive(true); // Show the pause menu

        // Enable ray interactors and disable direct interactors
        ToggleInteractors(true);

        // Stop the game timer by setting timeScale to 0
        timeScaleBeforePause = Time.timeScale; // Save the current timeScale
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false); // Hide the pause menu

        // Disable ray interactors and enable direct interactors
        ToggleInteractors(false);

        // Restore the game timer 
        Time.timeScale = timeScaleBeforePause;
    }

    private void UpdateTimerText()
    {
        // Update the timer text 
        timerText.text = $"Time: {gameTime:F2} seconds";
    }

    private void PositionPauseMenu()
    {
        // Position menu a certain distance in front of the camera
        float distanceFromCamera = 4.0f; 
        Vector3 position = cameraTransform.position + cameraTransform.forward * distanceFromCamera;

        // Align menu to face the camera
        pauseMenu.transform.position = position;
        pauseMenu.transform.rotation = Quaternion.LookRotation(pauseMenu.transform.position - cameraTransform.position);
    }

    private void ToggleInteractors(bool enableRayInteractors)
    {
        if (leftRay != null) leftRay.enabled = enableRayInteractors;
        if (rightRay != null) rightRay.enabled = enableRayInteractors;

        if (leftDirect != null) leftDirect.enabled = !enableRayInteractors;
        if (rightDirect != null) rightDirect.enabled = !enableRayInteractors;
    }

    private void OnResumeButtonClick()
    {
        ResumeGame();
    }

}
