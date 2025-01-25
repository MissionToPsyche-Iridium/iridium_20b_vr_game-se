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
    
    void Start()
    {
        //throws a NullReferenceException
        //scoreNumber.text = ScoreItem.getScore().ToString();
    }

    public void restartGameButton()
    {
        //enter code to load main game scene here
        Debug.Log("restart button pressed");
        SceneManager.LoadScene("MainGame");
    }

    public void exitButton()
    {
        //enter code to load credits scene here
        Debug.Log("exit button pressed");
    }


    
}
