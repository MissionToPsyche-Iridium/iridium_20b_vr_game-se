using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreNumber;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject gameOver;
    
    void Start()
    {
        credits.SetActive(false);
        gameOver.SetActive(true);
        scoreNumber.text = ScoreItem.getScore().ToString();
    }

    public void playButtonSound()
    {
        GetComponent<AudioSource>().Play();
    }

    public void restartGameButton()
    {

        Debug.Log("restart button pressed");
        playButtonSound();
        SceneManager.LoadScene("MainGame");
    }

    public void exitButton()
    {

        Debug.Log("exit button pressed");
        playButtonSound();
        credits.SetActive(true);
        gameOver.SetActive(false);
        
    }

    public void mainMenuButton()
    {
        playButtonSound();
        SceneManager.LoadScene("MainMenu");
    }


    
}
