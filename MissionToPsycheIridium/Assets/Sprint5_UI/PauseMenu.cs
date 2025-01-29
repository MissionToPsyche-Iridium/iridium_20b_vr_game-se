using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public InputActionReference pauseButton;
    public TMP_Text timerText;
    public Button resumeButton;
    public Button quitButton;
    public Button restartButton;
    public Transform cameraTransform;      // Reference to the camera
    public XRRayInteractor leftRay;        // Reference to left ray interactors
    public XRRayInteractor rightRay;       // Reference to right ray interactors
    public XRDirectInteractor leftDirect; // Reference to left direct interactor
    public XRDirectInteractor rightDirect; // Reference to right direct interactor
    public InputActionReference leftmoveAction; //Reference to left hand move action
    public InputActionReference rightmoveAction; //Reference to right hand move action
    public GameManager gameManager; //Reference to the game manager script

    private bool isPaused = false;         // Tracks when game is paused



    // Start is called before the first frame update
    void Start()
    {
        //Hide pause menu when game starts
        pauseMenu.SetActive(false);

        //Set up listener for resume button
        resumeButton.onClick.AddListener(OnResumeButtonClick);

        //Set up listener for quit button
        quitButton.onClick.AddListener(OnQuitButtonClick);

        //Set up listener for restart button
        restartButton.onClick.AddListener(OnRestartButtonClick);

        //Ensure interactors are off when game starts
        ToggleInteractors(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        pauseButton.action.performed += DisplayPause;
    }

    private void OnDisable()
    {
        pauseButton.action.performed -= DisplayPause;
    }

    private void DisplayPause(InputAction.CallbackContext context)
    {
        if (!isPaused)
        {
            //Pause the game if it is not paused and button is clicked
            PauseGame();
        }
    }

    private void PauseGame()
    {
        isPaused = true;

        //Show pause menu
        pauseMenu.SetActive(true);

        //Stop the timer
        gameManager.PauseTimer();

        // Enable ray interactors and disable direct interactors
        ToggleInteractors(true);

        //Disable player movement
        if (leftmoveAction != null) leftmoveAction.action.Disable();
        if (rightmoveAction != null) rightmoveAction.action.Disable();


        // Position pause menu in front of the camera
        PositionPauseMenu();
    }

    private void ResumeGame()
    {
        isPaused = false;

        // Hide the pause menu
        pauseMenu.SetActive(false);

        //Resume the timer
        gameManager.ResumeTimer();

        // Disable ray interactors and enable direct interactors
        ToggleInteractors(false);

        //Enable player movement
        if (leftmoveAction != null) leftmoveAction.action.Enable();
        if (rightmoveAction != null) rightmoveAction.action.Enable();
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

    private void OnQuitButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnRestartButtonClick()
    {
        gameManager.RestartGame();
    }

}