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
    public InputActionReference jumpAction; //Reference to the jump action
    public GameManager gameManager; //Reference to the game manager script
    public AudioSource bgm;
    public AudioSource pauseBgm;
    public bool initialPause;
    private bool isPaused = false;         // Tracks when game is paused
    public GameObject player;
    private Vector3 savedVelocity;
    private Vector3 savedAngularVelocity;



    void Start()
    {
        //Hide pause menu when game starts
        pauseMenu.SetActive(false);
        initialPause = false;

        //Set up listener for resume button
        resumeButton.onClick.AddListener(OnResumeButtonClick);

        //Set up listener for quit button
        quitButton.onClick.AddListener(OnQuitButtonClick);

        //Set up listener for restart button
        restartButton.onClick.AddListener(OnRestartButtonClick);

        //Ensure interactors are off when game starts
        ToggleInteractors(false);
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
        if (!initialPause)
        {
            pauseBgm.Play();
            initialPause = true;
        } else
        {
            pauseBgm.UnPause();
        }
        isPaused = true;
        bgm.Pause();
        
        //Show pause menu
        pauseMenu.SetActive(true);

        //Stop the timer
        gameManager.PauseTimer();

        // Freeze player mid-air
        player.GetComponent<Jump2>().PauseGame();

        // Enable ray interactors and disable direct interactors
        ToggleInteractors(true);

        //Disable player movement
        if (leftmoveAction != null) leftmoveAction.action.Disable();
        if (rightmoveAction != null) rightmoveAction.action.Disable();
        if (jumpAction != null) jumpAction.action.Disable();

        // Position pause menu in front of the camera
        PositionPauseMenu();
    }

    private void ResumeGame()
    {
        isPaused = false;
        bgm.UnPause();
        pauseBgm.Pause();
        // Hide the pause menu
        pauseMenu.SetActive(false);

        //Resume the timer
        gameManager.ResumeTimer();

        // Resume player movement
        player.GetComponent<Jump2>().ResumeGame();

        // Disable ray interactors and enable direct interactors
        ToggleInteractors(false);

        //Enable player movement
        if (leftmoveAction != null) leftmoveAction.action.Enable();
        if (rightmoveAction != null) rightmoveAction.action.Enable();
        if (jumpAction != null) jumpAction.action.Enable();
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