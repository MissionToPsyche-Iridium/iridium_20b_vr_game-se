using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
  
    public void backToMainMenu()
    {

        GetComponent<AudioSource>().Play();
        Debug.Log("main menu button pressed");
        SceneManager.LoadScene("MainMenu");
    }
}
