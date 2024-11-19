using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Timer Components")]
    [SerializeField] private float gameTime; // Total game time in seconds
    [SerializeField] private TextMeshProUGUI timeTextBox; // Text for timer
    [SerializeField] private GameObject gameOverPanel; // Reference to the game over UI

    // Start is called before the first frame update
    void Start()
    {
        // Make sure game over screen is hidden when game starts
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameTimer();
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
        else
        {
            // Prevent gameTime from going below zero
            gameTime = 0;

            // Display the Game Over panel
            if (gameOverPanel != null && !gameOverPanel.activeSelf)
            {
                gameOverPanel.SetActive(true);
            }
        }
    }
}
