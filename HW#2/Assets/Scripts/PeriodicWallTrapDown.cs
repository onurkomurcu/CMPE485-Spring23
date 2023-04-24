using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicWallTrapDown : MonoBehaviour
{
    public float speed = 1f;
    public float distance = 40f;
    public float smoothTime = 0.3f; // time taken to interpolate between positions
    public float waitTime = 5f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingDown = false;
    private float currentVelocity = 0f;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition - Vector3.down * distance; // set initial target position
        StartCoroutine("MoveObject"); // start coroutine
    }

    IEnumerator MoveObject()
    {
        while (true)
        {
            if (movingDown)
            {
                targetPosition = transform.position - Vector3.down * distance; // set new target position

            }
            else
            {
                targetPosition = transform.position + Vector3.down * distance;
            }
            movingDown = !movingDown;
            
            yield return new WaitForSeconds(waitTime); // wait for 2 seconds
        }
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime * speed * Time.deltaTime);
    }
}