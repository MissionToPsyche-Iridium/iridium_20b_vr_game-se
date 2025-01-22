using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; 
    public InputActionProperty pressPause;
    public Text timerText;                
    public Button resumeButton;           

    private bool isPaused = false;         // Tracks when game is paused
    private float gameTime = 0f;           // The game timer
    private float timeScaleBeforePause;    // Stores timer before pausing the game

    // Start is called before the first frame update
    void Start()
    {
        //Hide pause menu when game starts
        pauseMenu.SetActive(false);

        //Set up listener for resume button
        resumeButton.onClick.AddListener(ResumeGame);
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
        pauseMenu.SetActive(true); // Show the pause menu

        // Stop the game timer by setting timeScale to 0
        timeScaleBeforePause = Time.timeScale; // Save the current timeScale
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false); // Hide the pause menu

        // Restore the game timer 
        Time.timeScale = timeScaleBeforePause;
    }

    private void UpdateTimerText()
    {
        // Update the timer text 
        timerText.text = $"Time: {gameTime:F2} seconds";
    }

}
