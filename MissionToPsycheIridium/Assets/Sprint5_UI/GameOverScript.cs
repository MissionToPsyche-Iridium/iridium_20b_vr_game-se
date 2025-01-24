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

    public void restartGameButton()
    {
        //enter code to load main game scene here
    }

    public void exitButton()
    {
        //enter code to load credits scene here
    }


    
}
