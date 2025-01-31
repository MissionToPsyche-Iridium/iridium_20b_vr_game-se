using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
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
        //enter code to load main game scene here
        Debug.Log("restart button pressed");
        playButtonSound();
        SceneManager.LoadScene("MainGame");
    }

    public void exitButton()
    {
        //enter code to load credits scene here
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
