using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdScript : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public ScoreUI logic;
    public bool birdIsAlive = true;
    public float birdFallDistance = -15;
    public GameObject wingUp;
    public GameObject wingDown;
    public float timer = 0;
    public float wingFlap = 1;
    


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<ScoreUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
           
            timer = 0;
            myRigidBody.velocity = Vector2.up * flapStrength;
            wingFly();

        }

        if (timer > wingFlap)
        {
            wingFall();
        }
        

        if (transform.position.y < birdFallDistance)
        {
            logic.gameOver();
            Destroy(gameObject);
            Debug.Log("bird fell, destroyed");
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        Debug.Log("Game Over Activated");
        birdIsAlive = false;
    }

    private void wingFly()
    {
        wingUp.SetActive(true);
        wingDown.SetActive(false);
        
    }

    private void wingFall()
    {
        wingDown.SetActive(true);
        wingUp.SetActive(false);
    }
}
