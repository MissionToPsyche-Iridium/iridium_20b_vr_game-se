using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Floating : MonoBehaviour
{
    private bool floatUp;
    [SerializeField] private float tumble = 1.0f;
    [SerializeField] private float floatSpeed = 0.5f;
    [SerializeField] private float floatDistance = 0.5f;
    [SerializeField] private float floatDelay = 1f;
    public AudioClip collect;
    public Text score;
    private int collisions;

    void Start()
    {
        floatUp = true;
        GetComponent<Rigidbody>().angularVelocity = UnityEngine.Random.insideUnitSphere * tumble;
        StartCoroutine(FloatingRoutine());
        GetComponent<AudioSource>().clip = collect;
        GetComponent<AudioSource>().playOnAwake = false;
        collisions = 0;
       
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NonVR")
        {
            GetComponent<AudioSource>().Play();
        }
        if (collisions < 1)
        {

            if (other.gameObject.name == "leftHand" || other.gameObject.name == "rightHand" || other.gameObject.tag == "Player" || other.gameObject.name == "player")
            {
                collisions++;
                Debug.Log("collision detected, sound played");
                GetComponent<AudioSource>().Play();
                StartCoroutine(testing2());
                //Destroy(this.gameObject);


            }
        }
    }

    public IEnumerator testing2()
    {
        
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        Debug.Log("item set inactive");

        string currScore = score.text;

        int updateScore = Int32.Parse(currScore);

        updateScore++;


        score.text = updateScore.ToString();
    }

    IEnumerator FloatingRoutine()
    {
        while (true)
        {
            if (floatUp)
            {
                // Move up
                Vector3 targetPosition = transform.position + new Vector3(0, floatDistance, 0);
                while (transform.position.y < targetPosition.y)
                {
                    transform.position += new Vector3(0, floatSpeed * Time.deltaTime, 0);
                    yield return null;
                }
                floatUp = false;
            }
            else
            {
                // Move down
                Vector3 targetPosition = transform.position - new Vector3(0, floatDistance, 0);
                while (transform.position.y > targetPosition.y)
                {
                    transform.position -= new Vector3(0, floatSpeed * Time.deltaTime, 0);
                    yield return null;
                }
                floatUp = true;
            }
            // Wait before changing direction
            yield return new WaitForSeconds(floatDelay);
        }
    }
}
