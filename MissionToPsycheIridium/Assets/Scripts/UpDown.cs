using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    private Vector3 direction = Vector3.up;
    public int speed = 2;
    [SerializeField] GameObject plane;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        plane.transform.Translate(direction * speed * Time.deltaTime);

        if (plane.transform.position.y <= -2)
        {
            direction = Vector3.up;
        }
        else if (plane.transform.position.y >=2 )
        {
            direction = Vector3.down;
        }

    }



}
