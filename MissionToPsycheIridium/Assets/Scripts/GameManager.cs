using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Timer Components")]
    [SerializeField] private float gameTime; // Total game time in seconds
    [SerializeField] private TextMeshProUGUI timeTextBox; // Text for timer
    
    public Text score;
    public Text scoreVR;
    private GameObject eventSystem; //reference to EventSystem

    private float initialGameTime; // Store the original game time
    private bool isGameOver = false;
    private bool isTimerPaused = false;

    //setter and getter for isGameOver using C# Property
    public bool IsGameOver
    {
        get { return isGameOver; }
        set { isGameOver = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

        // Save the initial game time
        initialGameTime = gameTime;

        

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            
            UpdateGameTimer();

        }
        
    }

    private void UpdateGameTimer()
    {
        if (isTimerPaused) return;

        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;

            var minutes = Mathf.FloorToInt(gameTime / 60);
            var seconds = Mathf.FloorToInt(gameTime - minutes * 60);

            string gameTimeClock = string.Format("{0:0} : {1:00}", minutes, seconds);

            timeTextBox.text = gameTimeClock;
        }

        else
        {
            //Timer stops at 0
            gameTime = 0;

            //Set game over flag
            isGameOver = true;

            //Reset timer to 0
            timeTextBox.text = "0:00";

            ScoreItem.setScore(Int32.Parse(scoreVR.text));

            SceneManager.LoadScene("GameOver");

            
        }
    }

    public void PauseTimer()
    {
        isTimerPaused = true;
    }

    public void ResumeTimer()
    {
        isTimerPaused = false;
    }

    public void RestartGame()
    {
        //Reset the game time to the original value
        gameTime = initialGameTime;

        //Reset the game over state
        isGameOver = false;

        //Update timer test
        var minutes = Mathf.FloorToInt(gameTime / 60);
        var seconds = Mathf.FloorToInt(gameTime % 60);
        timeTextBox.text = string.Format("{0:0} : {1:00}", minutes, seconds);

        //Reset score

        //Reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}