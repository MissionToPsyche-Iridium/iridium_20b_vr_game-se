using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Timer Components")]
    [SerializeField] private float gameTime;
    [SerializeField] TextMeshProUGUI timeTextBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameTimer();
    }

    private void UpdateGameTimer()
    {
        gameTime -= Time.deltaTime;
        var minutes = Mathf.FloorToInt(gameTime / 60);
        var seconds = Mathf.FloorToInt(gameTime - minutes * 60);

        string gameTimeClock = string.Format("{0:0} : {1:00}", minutes, seconds);

        timeTextBox.text = gameTimeClock;

    }
}
