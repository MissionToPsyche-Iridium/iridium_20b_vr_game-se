using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour
{
    private Vector3 direction = Vector3.left;
    public int speed = 10;
    [SerializeField] GameObject plane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        plane.transform.Translate(direction * speed * Time.deltaTime);
        
        if (plane.transform.position.x < 2650)
        {
            direction = Vector3.right;
        } else if (plane.transform.position.x > 2672)
        {
            direction = Vector3.left;
        }
        
    }

    

}
