using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] GameObject disclaimer;
    [SerializeField] GameObject Tutorial;
    GameObject canvas;

    //this starts at the launch of scene
    void Start()
    {
        canvas = GameObject.Find("MainMenuCanvas");
        disclaimer.SetActive(false);
        Tutorial.SetActive(false);
    }

    //start game being pushed button
    //activates disclaimer "page"
    public void startGamePushed()
    {
        disclaimer.SetActive(true);
        canvas.SetActive(false);
    }

    //disclaimer continue then opens the tutorial
    public void switchToTutorial()
    {
        disclaimer.SetActive(false);
        Tutorial.SetActive(true);
    }

    //switches scene to game scene
    public void switchToGame()
    {
        
        SceneManager.LoadScene("MainGame");
       
    }


    //this code is for going back when on the disclaimer page
    public void goBack()
    {
        disclaimer.SetActive(false);
        canvas.SetActive(true);
    }

    //this code is for going back when on the tutorial page
    public void goBackDisclaimer()
    {
        Tutorial.SetActive(false);
        disclaimer.SetActive(true);
    }


    //this code quits the game. This has been confirmed to work in the test build. 
    public void quitGame()
    {
        Application.Quit();
    }
}
