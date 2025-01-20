using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

public class GameManager : MonoBehaviour
{
    [Header("Timer Components")]
    [SerializeField] private float gameTime; // Total game time in seconds
    [SerializeField] private TextMeshProUGUI timeTextBox; // Text for timer
    [SerializeField] private GameObject gameOverPanel; // Reference to the game over UI
    private GameObject eventSystem; //reference to EventSystem


    private bool isGameOver = false;
    //setter and getter for isGameOver using C# Property
    public bool IsGameOver
    {
        get { return isGameOver; }
        set { isGameOver = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Make sure game over screen is hidden when game starts
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        //show mouse cursor for debug (didn't work)
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
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
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;

            var minutes = Mathf.FloorToInt(gameTime / 60);
            var seconds = Mathf.FloorToInt(gameTime - minutes * 60);

            string gameTimeClock = string.Format("{0:0} : {1:00}", minutes, seconds);

            timeTextBox.text = gameTimeClock;
        }
        //need code here to reset timer after restart.  Or a new method?
        else
        {
            //Timer stops at 0
            gameTime = 0;

            //Set game over flag
            isGameOver = true;

            //Reset timer to 0
            timeTextBox.text = "0:00";

            //disable player input (experiment, this code can be used to disable stuff btw) 
            //but disabling the ISUIM component didn't work to halt player movement

            eventSystem = UnityEngine.GameObject.Find("EventSystem"); //get EventSystem gameObject
            InputSystemUIInputModule controls = eventSystem.GetComponent<InputSystemUIInputModule>(); //get ISUIM component
            controls.enabled = false;

            // Display the Game Over panel
            if (gameOverPanel != null && !gameOverPanel.activeSelf)
            {
                gameOverPanel.SetActive(true);
            }
        }
    }

}
