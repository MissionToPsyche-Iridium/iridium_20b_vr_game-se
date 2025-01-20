using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI scoreNumber;
    
    void Start()
    {
        scoreNumber.text = ScoreItem.getScore().ToString();
    }

    public void restartGame()
    {
        //probably load maingame scene from here
    }

    public void quitGame()
    {
        //probably shift this to credits
        //then quit
    }


    
}
