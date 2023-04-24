using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Calculate the target position based on the player's position and direction
        Vector3 targetPosition = target.position + target.forward * -2f + target.up * 3f;
        
        // Smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        
        // Rotate the camera to match the player's direction
        transform.rotation = Quaternion.LookRotation(target.forward, target.up);
    }
}