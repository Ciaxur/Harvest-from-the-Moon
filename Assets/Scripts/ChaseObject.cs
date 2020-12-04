using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseObject : MonoBehaviour {
    // External References & Settings
    public GameObject target;                    // Reference to the Object to Chase
    public float force = 50.0f;               // Speed of the Object
    
    // Internal References
    Rigidbody rb;

    // TODO: A* Path
    // Vector3 getChasePath() { }


    void Start() {
        // Validate Object Reference Given
        if (!target) {
            // Try and find the Player
            target = GameObject.FindGameObjectWithTag("Player");
            
            if (!target)
                Debug.LogAssertion("ChaseObject: No Reference Object to Chase");
        }

        rb = GetComponent<Rigidbody>();
        if (!rb) {
            Debug.LogAssertion("ChaseObject: No RigidBody Component");
        }
    }

    void LateUpdate() {
        // Chase that Path
        Vector3 desiredDir = (transform.position - target.transform.position).normalized;
        rb.AddForce(desiredDir * -force * Time.deltaTime);
    }
    
}
