using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject disclaimer;
    [SerializeField] GameObject Tutorial;
    GameObject canvas;
    private bool isEventMode;
    public AudioClip buttonSound;

    //this starts at the launch of scene
    void Start()
    {
        canvas = GameObject.Find("MainMenuCanvas");
        disclaimer.SetActive(false);
        Tutorial.SetActive(false);
        GetComponent<AudioSource>().clip = buttonSound;
        GetComponent<AudioSource>().playOnAwake = false;
    }

    void playButtonSound()
    {
        GetComponent<AudioSource>().Play();
    }

    //start game being pushed button
    //activates disclaimer "page"
    public void startGameButton()
    {
        playButtonSound();
        disclaimer.SetActive(true);
        canvas.SetActive(false);
        isEventMode = false;
    }

    //disclaimer continue then opens the tutorial
    public void switchToTutorial()
    {
        playButtonSound();
        disclaimer.SetActive(false);
        Tutorial.SetActive(true);
    }

    //switches scene to game scene
    public void startGame()
    {
        playButtonSound();
        //currently just loads event mode
        if (isEventMode)
        {
            SceneManager.LoadScene("MainGame");
        } else
        {
            SceneManager.LoadScene("MainGame");
        }
       
    }

    public void eventModeButton()
    {
        playButtonSound();
        //temporary
        disclaimer.SetActive(true);
        canvas.SetActive(false);
        isEventMode = true;
    }


    //this code is for going back when on the disclaimer page
    public void goBack()
    {
        playButtonSound();
        disclaimer.SetActive(false);
        canvas.SetActive(true);
    }

    //this code is for going back when on the tutorial page
    public void goBackDisclaimer()
    {
        playButtonSound();
        Tutorial.SetActive(false);
        disclaimer.SetActive(true);
    }

    public void goToCredits()
    {
        playButtonSound();
        SceneManager.LoadScene("Credits");
    }

    //this code quits the game. This has been confirmed to work in the test build. 
    public void exitButton()
    {
        playButtonSound();
        Application.Quit();
    }
}
