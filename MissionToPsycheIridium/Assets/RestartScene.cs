using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    private GameObject player;
    private GameObject manager;
   public void RestartGame()
    {
        //retrieves player gameObject
        player = UnityEngine.GameObject.Find("player");
        //retrieves GameManager gameObject
        manager = UnityEngine.GameObject.Find("GameManager");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        print("The button is working");
        //retrieves GameManager class from GameManager script
        //allows us to access fields in this class?
        GameManager gameManager = manager.GetComponent<GameManager>();
        //sets isGameOver to false
        gameManager.IsGameOver = false;
        //set player position to starting position
        player.transform.position = new Vector3(29.8f, -16.41f, -194.2f);
        //TODO: reset pickups
    }
}
