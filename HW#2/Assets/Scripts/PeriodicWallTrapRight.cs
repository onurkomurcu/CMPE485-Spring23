using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicWallTrapRight : MonoBehaviour
{
    public float speed = 1f;
    public float distance = 40f;
    public float smoothTime = 0.3f; // time taken to interpolate between positions

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingForward = false;
    private float currentVelocity = 0f;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition - Vector3.forward * distance; // set initial target position
        StartCoroutine("MoveObject"); // start coroutine
    }

    IEnumerator MoveObject()
    {
        while (true)
        {
            if (movingForward)
            {
                targetPosition = transform.position - Vector3.forward * distance; // set new target position

            }
            else
            {
                targetPosition = transform.position + Vector3.forward * distance;
            }
            movingForward = !movingForward;
            
            yield return new WaitForSeconds(5f); // wait for 2 seconds
        }
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime * speed * Time.deltaTime);
    }
}