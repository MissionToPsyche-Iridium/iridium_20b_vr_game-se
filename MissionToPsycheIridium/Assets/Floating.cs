using System.Collections;
using UnityEngine;

public class Floating : MonoBehaviour
{
    private bool floatUp;
    [SerializeField] private float tumble = 1.0f;
    [SerializeField] private float floatSpeed = 0.5f;
    [SerializeField] private float floatDistance = 0.5f;
    [SerializeField] private float floatDelay = 1f;

    void Start()
    {
        floatUp = true;
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        StartCoroutine(FloatingRoutine());
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
