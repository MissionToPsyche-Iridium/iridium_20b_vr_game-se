using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreNumber;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI nickelText;
    [SerializeField] TextMeshProUGUI silverText;
    [SerializeField] TextMeshProUGUI ironText;
    [SerializeField] TextMeshProUGUI researchText;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject gameOver;
    
    void Start()
    {
        credits.SetActive(false);
        gameOver.SetActive(true);
        //gets score from ScoreItem
        scoreNumber.text = ScoreItem.getScore().ToString();
        //gets silver qty from ScoreItem
        silverText.text = ScoreItem.getSilverQty().ToString();
        //gets iron qty from ScoreItem
        ironText.text = ScoreItem.getIronQty().ToString();
        //gets gold qty from ScoreItem
        goldText.text = ScoreItem.getGoldQty().ToString();
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
