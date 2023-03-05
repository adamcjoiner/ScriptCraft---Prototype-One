using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed;
    private Vector3 cameraForward, cameraRight;

    void Start()
    {
        // Initialize camera's forward and right vectors
        cameraForward = transform.forward;
        cameraForward.y = 0f;
        cameraForward = cameraForward.normalized;
        cameraRight = transform.right.normalized;
    }

    void LateUpdate()
    {
        // Update camera's forward and right vectors to match player's
        Vector3 playerForward = playerTransform.forward;
        playerForward.y = 0f;
        playerForward = playerForward.normalized;
        Vector3 playerRight = playerTransform.right.normalized;

        // Interpolate smoothly between current camera vectors and player vectors
        float t = Time.deltaTime * moveSpeed;
        cameraForward = Vector3.Lerp(cameraForward, playerForward, t);
        cameraRight = Vector3.Lerp(cameraRight, playerRight, t);

        // Update camera's transform to match new forward and right vectors
        transform.forward = cameraForward;
        transform.right = cameraRight;
    }
}
