using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    // References
    public GameObject entityToFollow;       // Entity to Follow

    // Settings
    public Vector3 offset;                  // Camera Offset
    public float smoothSpeed = 0.125f;      // The "lag" of the Camera Movement
    

    void LateUpdate() {
        // Nothing to Follow
        if (!entityToFollow) {
            return;
        }
        
        // Calculate the Desired Position of the Camera
        // Only X & Z Movement
        Vector3 desiredPosition = offset + new Vector3(
            entityToFollow.transform.position.x,
            transform.position.y,
            entityToFollow.transform.position.z
        );

        // Add the smoothness to the Camera
        Vector3 newPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.fixedDeltaTime
        );

        // Apply Movement
        transform.position = newPosition;
    }
}
