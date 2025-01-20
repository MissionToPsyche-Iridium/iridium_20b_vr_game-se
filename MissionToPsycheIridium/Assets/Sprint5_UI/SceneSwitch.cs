using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] GameObject disclaimer;
    GameObject canvas;

    void Start()
    {
        canvas = GameObject.Find("MainMenuCanvas");
        disclaimer.SetActive(false);
    }

    public void startGamePushed()
    {
        disclaimer.SetActive(true);
        canvas.SetActive(false);
    }
    public void switchToGame()
    {
        
        SceneManager.LoadScene("MainGame");
       
    }

    public void goBack()
    {
        disclaimer.SetActive(false);
        canvas.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
